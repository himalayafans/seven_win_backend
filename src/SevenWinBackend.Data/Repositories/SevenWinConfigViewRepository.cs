using SevenWinBackend.Application.Repositories;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace SevenWinBackend.Data.Repositories
{
    internal class SevenWinConfigViewRepository : ISevenWinConfigViewRepository
    {
        private IDatabase Db { get; }

        public SevenWinConfigViewRepository(IDatabase db)
        {
            Db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<List<SevenWinConfigView>> GetConfigViews(string guildDiscordId)
        {
            if (string.IsNullOrWhiteSpace(guildDiscordId))
            {
                throw new ArgumentNullException(nameof(guildDiscordId));
            }
            string sql = "select * from seven_win_config_view where guild_discord_id=@GuildDiscordId;";
            return await this.Db.FetchAsync<SevenWinConfigView>(sql, new { GuildDiscordId = guildDiscordId });
        }
    }
}
