using PetaPoco;
using SevenWinBackend.Application.Interfaces;
using SevenWinBackend.Application.Repositories;
using SevenWinBackend.Data.Base;
using SevenWinBackend.Domain.Common;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Data.Repositories
{
    internal class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(IDatabase db) : base(db)
        {
        }

        public async Task<Player?> GetByDiscordId(string discordId)
        {
            if (string.IsNullOrWhiteSpace(discordId))
            {
                throw new ArgumentNullException(nameof(discordId));
            }
            string sql = "SELECT * FROM player WHERE discord_id=@DiscordId;";
            return await this.Db.SingleOrDefaultAsync<Player?>(sql, new { DiscordId = discordId });
        }

        public Task<PageResult<Player>> Search(IQueryOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
