using Microsoft.Extensions.Logging;
using PetaPoco;
using SevenWinBackend.Application.Common;
using SevenWinBackend.Application.Data;
using SevenWinBackend.Domain.Common;
using SevenWinBackend.Domain.Entities;
using SevenWinBackend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Data
{
    public class Database : SevenWinBackend.Application.Data.IDatabase
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public Database(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
        }
        public async Task Seed()
        {
            using var work = this.unitOfWorkFactory.Create();
            work.BeginTransaction();
            try
            {
                // 获取数据库中表的总数
                string sql = @"SELECT count(*)
                           FROM pg_catalog.pg_tables
                           WHERE schemaname != 'pg_catalog' AND 
                           schemaname != 'information_schema';";
                var count = await work.ExecuteScalarAsync<int>(sql);
                if (count > 0)
                {
                    Console.WriteLine("Database initialization failed because table already exists.");
                    return;
                }
                Console.WriteLine("Start creating data tables...");
                await work.ExecuteAsync(Properties.Resources.DBSQL);
                Console.WriteLine("Create data table completed successfully.");
                // 创建管理员
                Account account = Account.Create("admin", "123456", Domain.Enums.RolesType.Admin);
                await work.Account.Add(account);
                // 创建配置
                Config appIdConfig = Config.Create(ConfigKeyNames.AppId, Constants.AppId);
                await work.Config.Add(appIdConfig);
                Config dbVersionConfig = Config.Create(ConfigKeyNames.DbVersion, new Version(1, 0).ToString());
                await work.Config.Add(dbVersionConfig);
                Console.WriteLine("Seeding the database completed successfully!");
            }
            catch (Exception)
            {
                work.Rollback();
                throw;
            }
        }

        public Task Update()
        {
            throw new NotImplementedException();
        }
    }
}