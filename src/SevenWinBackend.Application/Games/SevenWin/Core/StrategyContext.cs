using Discord.WebSocket;
using SevenWinBackend.Application.Common;
using SevenWinBackend.Application.Data;
using SevenWinBackend.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SevenWinBackend.Domain.Entities;

namespace SevenWinBackend.Application.Games.SevenWin.Core
{
    /// <summary>
    /// 策略上下文
    /// </summary>
    internal class StrategyContext
    {
        public PlayResult PlayResult { get; }
        public IOcrResult? OcrResult { get; set; }
        public DiscordImageInfo DiscordImageInfo { get; }
        public DataCache Cache { get; }
        public SocketUserMessage SocketUserMessage { get; }
        public IServiceProvider ServiceProvider { get; }

        public StrategyContext(PlayResult playResult, SocketUserMessage socketUserMessage, IServiceProvider serviceProvider, DiscordImageInfo discordImageInfo, DataCache cache)
        {
            PlayResult = playResult ?? throw new ArgumentNullException(nameof(playResult));
            SocketUserMessage = socketUserMessage ?? throw new ArgumentNullException(nameof(socketUserMessage));
            ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            DiscordImageInfo = discordImageInfo ?? throw new ArgumentNullException(nameof(discordImageInfo));
            Cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }
        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// <returns></returns>

        public ulong GetUserDiscordId()
        {
            return SocketUserMessage.Author.Id;
        }
        /// <summary>
        /// 获取频道ID
        /// </summary>
        /// <returns></returns>
        public ulong GetChannelDiscordId()
        {
            return SocketUserMessage.Channel.Id;
        }
        /// <summary>
        /// 获取服务器ID
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public ulong GetGuildDiscordId()
        {
            var channel = SocketUserMessage.Channel as SocketGuildChannel;
            if (channel == null)
            {
                throw new InvalidOperationException("Channel in message is not SocketGuildChannel");
            }
            return channel.Guild.Id;
        }
        /// <summary>
        /// 获取Discord服务器
        /// </summary>
        public SocketGuild GetDiscordGuild()
        {
            var channel = SocketUserMessage.Channel as SocketGuildChannel;
            if (channel == null)
            {
                throw new InvalidOperationException("Channel in message is not SocketGuildChannel");
            }
            return channel.Guild;
        }
    }
}