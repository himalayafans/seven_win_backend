using SevenWinBackend.Application.Base;
using SevenWinBackend.Application.Interfaces;
using SevenWinBackend.Domain.Common;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Repositories
{
    /// <summary>
    /// 玩家存储库
    /// </summary>
    public interface IPlayerRepository : IRepository<Player>
    {
        /// <summary>
        /// 通过discord ID获取玩家
        /// </summary>
        Task<Player> GetByDiscordId(ulong discordId);
        /// <summary>
        /// 搜索玩家
        /// </summary>
        Task<PageResult<Player>> Search(IQueryOptions options);
    }
}
