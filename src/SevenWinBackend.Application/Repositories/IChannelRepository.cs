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
        public Task<Channel?> GetByDiscordId(string discordId);
        /// <summary>
        /// 判断Discord频道是否存在
        /// </summary>
        public Task<bool> Contains(string discordId);
    }
}