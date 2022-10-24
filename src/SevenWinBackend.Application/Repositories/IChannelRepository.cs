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
    /// Discord频道存储库
    /// </summary>
    public interface IChannelRepository : IRepository<Channel>
    {
        public Task<Channel> GetByDiscordId(ulong discordId);
    }
}