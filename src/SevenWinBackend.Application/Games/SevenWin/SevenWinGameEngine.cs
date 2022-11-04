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
        private readonly IImageService imageService;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly IWebHostEnvironment env;
        private readonly HttpService httpService;
        private readonly IServiceProvider serviceProvider;

        public SevenWinGameEngine(ILogger<SevenWinGameEngine> logger, IOcrService ocrService,
            IImageService imageService, IUnitOfWorkFactory unitOfWorkFactory, IWebHostEnvironment environment,
            HttpService httpService, IServiceProvider serviceProvider)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.ocrService = ocrService ?? throw new ArgumentNullException(nameof(ocrService));
            this.imageService = imageService ?? throw new ArgumentNullException(nameof(imageService));
            this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
            env = environment ?? throw new ArgumentNullException(nameof(environment));
            this.httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 获取消息中的图片，若不存在则返回null
        /// </summary>
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

        public override async Task Handle(SocketUserMessage message, PlayResult playResult)
        {
            if (!string.IsNullOrWhiteSpace(message.CleanContent)) // 如果消息包含文本，则忽略消息
            {
                await (Successor?.Handle(message, playResult) ?? Task.CompletedTask);
            }
            else
            {
                DiscordImageInfo? imageInfo = await GetImage(message);
                if (imageInfo == null) // 如果Discord消息不包含图片，则忽略消息
                {
                    await (Successor?.Handle(message, playResult) ?? Task.CompletedTask);
                }
                else
                {
                    StrategyContext context = new StrategyContext(playResult, message, this.serviceProvider, imageInfo, new DataCache());
                    CheckChannelPolicy checkChannelPolicy = new CheckChannelPolicy();
                    // 必须先检查频道，再检查时间，因为时间不符合，会产生反馈信息
                    CheckDiscordTimeStrategy checkDiscordTimeStrategy = new CheckDiscordTimeStrategy();
                    checkChannelPolicy.SetSuccessor(checkDiscordTimeStrategy);
                    CheckPlayerPolicy checkPlayerPolicy = new CheckPlayerPolicy();
                    checkDiscordTimeStrategy.SetSuccessor(checkPlayerPolicy);
                    await checkChannelPolicy.Handle(context);
                }
            }
        }
    }
}
