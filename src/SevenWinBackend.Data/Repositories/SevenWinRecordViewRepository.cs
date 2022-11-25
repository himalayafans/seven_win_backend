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

        public async Task<SevenWinRecordView?> GetBaseGameInOneMinute(Guid playerId, Guid guildId)
        {
            DateTime time = DateTime.Now.AddMinutes(-1);
            string sql = @"select *
                           from seven_win_record_view
                           where player_id = @PlayerId
                               and guild_id = @GuildId
                               and created_at >= @CreatedAt
                               and is_base = true;";
            return await this.Db.SingleOrDefaultAsync<SevenWinRecordView?>(sql, new { PlayerId = playerId, GuildId = guildId, CreatedAt = time });
        }

        public async Task<List<SevenWinRecordView>> GetAdditionalGamesInOneMinute(Guid playerId, Guid guildId)
        {
            DateTime time = DateTime.Now.AddMinutes(-1);
            string sql = @"select *
                           from seven_win_record_view
                           where player_id = @PlayerId
                               and guild_id = @GuildId
                               and created_at >= @CreatedAt
                               and is_base = false;";
            return await this.Db.FetchAsync<SevenWinRecordView>(sql, new { PlayerId = playerId, GuildId = guildId, CreatedAt = time });
        }
        /// <summary>
        /// 基础游戏中是否存在相同的图片
        /// </summary>
        public async Task<bool> IsExistSameImageInBaseGame(Guid imageId)
        {
            string sql = @"select count(*)
                       from seven_win_record_view
                       where image_id = @ImageId
                       and is_base = false;";
            int count = await this.Db.ExecuteScalarAsync<int>(sql, new { ImageId = imageId });
            return count > 0;
        }
    }
}
