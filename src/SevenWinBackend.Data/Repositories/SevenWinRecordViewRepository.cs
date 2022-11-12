using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;
using SevenWinBackend.Application.Repositories;
using SevenWinBackend.Domain.Entities;

namespace SevenWinBackend.Data.Repositories
{
    internal class SevenWinRecordViewRepository : ISevenWinRecordViewRepository
    {
        private IDatabase Db { get; }

        public SevenWinRecordViewRepository(IDatabase db)
        {
            Db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<SevenWinRecordView?> GetBaseGameInOneMinute(string discordUserId, string guildDiscordId)
        {
            DateTime time = DateTime.Now.AddMinutes(-1);
            string sql = @"select *
                           from seven_win_record_view
                           where guild_discord_id = @GuildDiscordId
                           and player_discord_id = @PlayerDiscordId
                           and created_at >= @CreatedAt
                           and is_base = true;";
            return await this.Db.SingleOrDefaultAsync<SevenWinRecordView?>(sql, new { GuildDiscordId = guildDiscordId, PlayerDiscordId = discordUserId, CreatedAt = time });
        }

        public async Task<List<SevenWinRecordView>> GetAdditionalGamesInOneMinute(string discordUserId, string guildDiscordId)
        {
            DateTime time = DateTime.Now.AddMinutes(-1);
            string sql = @"select *
                           from seven_win_record_view
                           where guild_discord_id = @GuildDiscordId
                           and player_discord_id = @PlayerDiscordId
                           and created_at >= @CreatedAt
                           and is_base = false;";
            return await this.Db.FetchAsync<SevenWinRecordView>(sql, new { GuildDiscordId = guildDiscordId, PlayerDiscordId = discordUserId, CreatedAt = time });
        }
    }
}
