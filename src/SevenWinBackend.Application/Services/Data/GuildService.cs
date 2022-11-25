using SevenWinBackend.Application.Data;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Services.Data
{
    /// <summary>
    /// Discord工会服务
    /// </summary>
    public class GuildService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public GuildService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
        }
        /// <summary>
        /// 通过Discord ID获取服务器
        /// </summary>
        public async Task<Guild?> GetByDiscordId(string discordId)
        {
            if (string.IsNullOrWhiteSpace(discordId))
            {
                throw new ArgumentNullException(nameof(discordId));
            }
            using var work = this.unitOfWorkFactory.Create();
            return await work.Guild.GetByDiscordId(discordId);
        }
        /// <summary>
        /// 插入服务器数据
        /// </summary>
        public async Task Insert(Guild guild)
        {
            using var work = this.unitOfWorkFactory.Create();
            await work.Guild.Insert(guild);
        }
    }
}
