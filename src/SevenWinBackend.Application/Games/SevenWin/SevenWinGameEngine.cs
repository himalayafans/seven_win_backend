using Discord.Rest;
using Discord.WebSocket;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using SevenWinBackend.Application.Base;
using SevenWinBackend.Application.Common;
using SevenWinBackend.Application.Data;
using SevenWinBackend.Application.Interfaces;
using SevenWinBackend.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SevenWinBackend.Common;
using SevenWinBackend.Application.Exceptions;
using SevenWinBackend.Application.Games.SevenWin.Core;
using SevenWinBackend.Application.Games.SevenWin.Strategies;
using SevenWinBackend.Application.Options;
using Microsoft.Extensions.DependencyInjection;
using SevenWinBackend.Application.Services.Data;
using SevenWinBackend.Domain.Entities;

namespace SevenWinBackend.Application.Games.SevenWin
{
    /// <summary>
    /// 出7制胜游戏引擎
    /// </summary>
    public class SevenWinGameEngine : BaseGameEngine
    {
        private static readonly List<string> ImageTypes = new List<string>()
        {
            "image/jpeg",
            //"image/gif",
            "image/png",
            //"image/bmp"
        };

        private readonly ILogger<SevenWinGameEngine> logger;
        private readonly IOcrService ocrService;
        private readonly ImageHandlerService imageService;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly HttpService httpService;
        private readonly IServiceProvider serviceProvider;

        public SevenWinGameEngine(ILogger<SevenWinGameEngine> logger, IOcrService ocrService,
            ImageHandlerService imageService, IUnitOfWorkFactory unitOfWorkFactory, 
            HttpService httpService, IServiceProvider serviceProvider)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.ocrService = ocrService ?? throw new ArgumentNullException(nameof(ocrService));
            this.imageService = imageService ?? throw new ArgumentNullException(nameof(imageService));
            this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
            this.httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 获取消息中的图片，若不存在则返回null
        /// </summary>
        /// <exception cref="AppException"></exception>
        private async Task<DiscordImageInfo?> GetImage(SocketUserMessage message)
        {
            var images = message.Attachments.Where(p => ImageTypes.Contains(p.ContentType)).ToList();
            if (images.Count == 0)
            {
                return null;
            }
            if (images.Count > 1)
            {
                throw new AppException("本次活动参与无效，一次只能上传一张图片");
            }

            var file = message.Attachments.First();
            var stream = await httpService.DownloadAsStream(file.Url);
            var hash = stream.GetMd5HashCode();
            ImageSize imageSize = new ImageSize(file.Width.GetValueOrDefault(), file.Height.GetValueOrDefault());
            return new DiscordImageInfo(file.Url, hash, imageSize, stream);
        }

        public override async Task Handle(SocketUserMessage message, SocketGuildChannel channel, SocketGuildUser user, PlayResult playResult)
        {
            if (!string.IsNullOrWhiteSpace(message.CleanContent)) // 如果消息包含文本，则忽略消息
            {
                await (Successor?.Handle(message, channel, user, playResult) ?? Task.CompletedTask);
            }
            else
            {
                DiscordImageInfo? imageInfo = await GetImage(message);
                if (imageInfo == null) // 如果Discord消息不包含图片，则忽略消息
                {
                    await (Successor?.Handle(message, channel, user, playResult) ?? Task.CompletedTask);
                }
                else
                {
                    SettingOptions options = this.serviceProvider.GetRequiredService<SettingOptions>();
                    // 检查是否是参与游戏的服务器
                    var gameGuild = options.SevenWinGuildOptions.FirstOrDefault(p => p.DiscordId == channel.Guild.Id.ToString());
                    if (gameGuild != null)
                    {
                        // 检查是否是参与游戏的频道
                        var gameChannel = gameGuild.Channels.FirstOrDefault(p => p.DiscordId == channel.Id.ToString());
                        if (gameChannel != null)
                        {
                            ChannelService channelService = this.serviceProvider.GetRequiredService<ChannelService>();
                            Channel? c = await channelService.GetByDiscordId(gameChannel.DiscordId);
                            GuildService guildService = this.serviceProvider.GetRequiredService<GuildService>();
                            Guild? g = await guildService.GetByDiscordId(gameGuild.DiscordId);
                            if (c != null && g != null)
                            {
                                // 游戏核心算法
                                DataCache cache = new DataCache();
                                cache.ChannelId = c.Id;
                                cache.GuildId = g.Id;
                                StrategyContext context = new StrategyContext(playResult, message, this.serviceProvider, imageInfo, cache, gameGuild, user);
                                CheckDiscordTimeStrategy timeCheckStrategy = new CheckDiscordTimeStrategy();
                                CacheInitPolicy cacheInitPolicy = new CacheInitPolicy();
                                timeCheckStrategy.SetSuccessor(cacheInitPolicy);
                                EmptyTextStrategy emptyTextStrategy = new EmptyTextStrategy();
                                cacheInitPolicy.SetSuccessor(emptyTextStrategy);
                                LogoStrategy logoStrategy = new LogoStrategy();
                                emptyTextStrategy.SetSuccessor(logoStrategy);
                                PostTimeCheckStrategy postTimeCheckStrategy = new PostTimeCheckStrategy();
                                logoStrategy.SetSuccessor(postTimeCheckStrategy);
                                GameCheckStrategy gameCheckStrategy = new GameCheckStrategy();
                                postTimeCheckStrategy.SetSuccessor(gameCheckStrategy);
                                GameBaseStrategy gameBaseStrategy = new GameBaseStrategy();
                                gameCheckStrategy.SetSuccessor(gameBaseStrategy);
                                GameAdditionStrategy additionStrategy = new GameAdditionStrategy();
                                gameBaseStrategy.SetSuccessor(additionStrategy);
                                await timeCheckStrategy.Handle(context);
                            }
                            else
                            {
                                await (Successor?.Handle(message, channel, user, playResult) ?? Task.CompletedTask);
                            }
                        }
                        else
                        {
                            await (Successor?.Handle(message, channel, user, playResult) ?? Task.CompletedTask);
                        }
                    }
                    else
                    {
                        await (Successor?.Handle(message, channel, user, playResult) ?? Task.CompletedTask);
                    }
                }
            }
        }
    }
}
