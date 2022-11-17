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

        public async Task<PageResult<Player>> Search(IQueryOptions options)
        {
            if (options.PageSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(options.PageSize));
            }
            if (options.Page < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(options.Page));
            }
            SqlBuilder sql = new SqlBuilder();
            sql.AppendToEnd("select * from player");
            if (!string.IsNullOrWhiteSpace(options.SearchValue))
            {
                sql.AppendToEnd("where discord_id=@Value or display_name like @Value");
                sql.AddParameter("Value", $"%{options.SearchValue.Trim()}");
            }
            sql.AppendToEnd("order by score desc");
            var query = sql.GetQuery();
            var result = await this.Db.PageAsync<Player>(options.Page, options.PageSize, query.Sql, query.DynamicParameters);
            return new PageResult<Player>(options.Page, options.PageSize, result.TotalItems, result.Items);
        }
    }
}
