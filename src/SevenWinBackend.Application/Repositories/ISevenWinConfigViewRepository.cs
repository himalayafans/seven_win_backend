using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Repositories
{
    public interface ISevenWinConfigViewRepository
    {
        /// <summary>
        /// 获取指定服务器的所有频道配置
        /// </summary>
        /// <param name="guildDiscordId">服务器Discord ID</param>
        Task<List<SevenWinConfigView>> GetConfigViews(string guildDiscordId);
    }
}