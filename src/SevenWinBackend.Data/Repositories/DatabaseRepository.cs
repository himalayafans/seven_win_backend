using PetaPoco;
using SevenWinBackend.Application.Repositories;
using SevenWinBackend.Domain.Entities;
using SevenWinBackend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Data.Repositories
{
    internal class DatabaseRepository : IDatabaseRepository
    {
        private IDatabase Db { get; }

        public DatabaseRepository(IDatabase db)
        {
            Db = db ?? throw new ArgumentNullException(nameof(db));
        }

        async Task IDatabaseRepository.ClearData()
        {
            string sql = @"delete from account;
                           delete from channel;
                           delete from config;
                           delete from image;
                           delete from guild;
                           delete from player;
                           delete from player_game;
                           delete from seven_win_config;
                           delete from seven_win_record;";
            await this.Db.ExecuteAsync(sql);
        }

        async Task IDatabaseRepository.CreateTables()
        {
            string sql = Properties.Resources.DBSQL;
            await this.Db.ExecuteAsync(sql);
        }

        async Task IDatabaseRepository.DeleteTables()
        {
            string sql = @"drop view player_game_view;
                           drop view seven_win_config_view;
                           drop view seven_win_record_view;
                           drop table account;
                           drop table channel;
                           drop table config;
                           drop table image;
                           drop table guild;
                           drop table player;
                           drop table player_game;
                           drop table seven_win_config;
                           drop table seven_win_record;";
            await this.Db.ExecuteAsync(sql);
        }

        async Task<bool> IDatabaseRepository.IsExistTables()
        {
            // 获取数据库中表的总数
            string sql = @"SELECT count(*)
                           FROM pg_catalog.pg_tables
                           WHERE schemaname != 'pg_catalog' AND 
                           schemaname != 'information_schema';";
            var count = await this.Db.ExecuteScalarAsync<int>(sql);
            return count > 0;
        }

        Task IDatabaseRepository.UpdateTables(Version version)
        {
            return Task.CompletedTask;
        }
    }
}
