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
using PetaPoco;
using SqlKata;
using SevenWinBackend.Common;

namespace SevenWinBackend.Data.Repositories
{
    internal class PlayerGameViewRepository : IPlayerGameViewRepository
    {
        private IDatabase Db { get; }

        public PlayerGameViewRepository(IDatabase db)
        {
            Db = db ?? throw new ArgumentNullException(nameof(db));
        }

        async Task<PageResult<PlayerGameView>> IPlayerGameViewRepository.Search(IQueryOptions options)
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
            sql.AppendToEnd("select * from player_game_view where 1=1");
            if (!string.IsNullOrWhiteSpace(options.SearchValue))
            {
                string value = options.SearchValue.Trim();
                sql.AppendToEnd("and player_full_name like @Value");
                sql.AddParameter("@Value", value);
            }
            if (options.StartTime != null && options.StartTime > 0)
            {
                DateTime startTime = DateTimeHelper.FromTimestamp(options.StartTime.Value);
                sql.AppendToEnd("and created_at >= @StartDate");
                sql.AddParameter("@StartDate", new DateTime(startTime.Year, startTime.Month, startTime.Day, 0, 0, 0));
            }
            if (options.EndTime != null && options.EndTime > 0)
            {
                DateTime endTime = DateTimeHelper.FromTimestamp(options.EndTime.Value);
                sql.AppendToEnd("and created_at >= @EndDate");
                sql.AddParameter("@EndDate", new DateTime(endTime.Year, endTime.Month, endTime.Day, 23, 59, 59));
            }
            if (string.IsNullOrWhiteSpace(options.SortBy))
            {
                sql.AppendToEnd("order by score desc,id asc");
            }
            else
            {
                string sort = options.SortBy.Trim().ToSnakeCase();
                if (options.IsSortAscending == null)
                {
                    sql.AppendToEnd($"order by {sort} desc,id asc");
                }
                else if (options.IsSortAscending.Value)
                {
                    sql.AppendToEnd($"order by {sort} asc,id asc");
                }
                else
                {
                    sql.AppendToEnd($"order by {sort} desc,id asc");
                }
            }
            var query = sql.GetQuery();
            var result = await this.Db.PageAsync<PlayerGameView>(options.Page, options.PageSize, query.Sql, query.DynamicParameters);
            return new PageResult<PlayerGameView>(options.Page, options.PageSize, result.TotalItems, result.Items);
        }
    }
}
