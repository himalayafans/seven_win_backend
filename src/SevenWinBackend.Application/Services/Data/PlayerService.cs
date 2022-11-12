using Discord.WebSocket;
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
    /// 玩家服务
    /// </summary>
    public class PlayerService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public PlayerService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
        }
        /// <summary>
        /// 如果玩家不存在，则添加记录，若已存在，则返回现有玩家记录
        /// </summary>
        public async Task<Player> GetOrAdd(SocketGuildUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            using var work = this.unitOfWorkFactory.Create();
            var player = await work.Player.GetByDiscordId(user.Id.ToString());
            if (player == null)
            {
                player = Player.Create(user.Id.ToString(), user.DisplayName, user.Discriminator, user.AvatarId);
                await work.Player.Insert(player);
            }
            return player;
        }
    }
}
