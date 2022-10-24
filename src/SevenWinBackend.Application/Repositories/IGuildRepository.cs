using SevenWinBackend.Application.Base;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Repositories
{
    /// <summary>
    /// Discord服务器储存库
    /// </summary>
    public interface IGuildRepository : IRepository<Guild>
    {
        /// <summary>
        /// 通过Discord ID获取Discord服务器
        /// </summary>
        Task<Guild> GetByDiscordId(ulong discordId);
    }
}
