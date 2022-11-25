using SevenWinBackend.Application.Data;
using SevenWinBackend.Domain.Entities;
using SevenWinBackend.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Services.Data
{
    public class PlayerGameService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public PlayerGameService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
        }
        public async Task<PlayerGame?> GetPlayerGameById(Guid id)
        {
            using var work = unitOfWorkFactory.Create();
            return await work.PlayerGame.GetById(id);
        }
        public async Task Update(PlayerGame game)
        {
            using var work = unitOfWorkFactory.Create();
            await work.PlayerGame.Update(game);
        }
        public async Task Update(Guid playerGameId, IScoreDetail detail)
        {
            if (playerGameId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(playerGameId));
            }
            if (detail == null)
            {
                throw new ArgumentNullException(nameof(detail));
            }
            using var work = unitOfWorkFactory.Create();
            PlayerGame? game = await work.PlayerGame.GetById(playerGameId);
            if (game != null)
            {
                game.SetScoreDetail(detail);
                await work.PlayerGame.Update(game);
            }
        }
    }
}
