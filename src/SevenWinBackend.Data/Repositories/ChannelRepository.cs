using PetaPoco;
using SevenWinBackend.Application.Repositories;
using SevenWinBackend.Data.Base;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Data.Repositories
{
    internal class ChannelRepository : BaseRepository<Channel>, IChannelRepository
    {
        public ChannelRepository(IDatabase db) : base(db)
        {
        }

        public async Task<bool> Contains(string discordId)
        {
            if (string.IsNullOrWhiteSpace(discordId))
            {
                throw new ArgumentNullException(nameof(discordId));
            }
            string sql = "select * from channel where discord_id = @DiscordId;";
            int count = await this.Db.ExecuteScalarAsync<int>(sql, new { DiscordId = discordId });
            return count > 0;
        }

        public async Task<Channel?> GetByDiscordId(string discordId)
        {
            if (string.IsNullOrWhiteSpace(discordId))
            {
                throw new ArgumentNullException(nameof(discordId));
            }
            string sql = "select * from channel where discord_id = @DiscordId;";
            return await this.Db.SingleOrDefaultAsync<Channel?>(sql, new { DiscordId = discordId });
        }
    }
}
