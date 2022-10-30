using SevenWinBackend.Application.Base;
using SevenWinBackend.Domain.Entities;
using SevenWinBackend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Repositories
{
    /// <summary>
    /// Discord频道存储库
    /// </summary>
    public interface IChannelRepository : IRepository<Channel>
    {
        /// <summary>
        /// 通过discord ID获取频道
        /// </summary>
        public Task<Channel> GetByDiscordId(ulong discordId);
        /// <summary>
        /// 获取指定游戏能参与的频道
        /// </summary>
        public Task<List<Channel>> GetChannelsWithGameType(GameTypes types);
    }
}