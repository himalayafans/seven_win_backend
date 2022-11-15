using SevenWinBackend.Application.Data;
using SevenWinBackend.Domain.Common;
using SevenWinBackend.Domain.Entities;
using SevenWinBackend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Services.Data
{
    /// <summary>
    /// 数据库服务
    /// </summary>
    public class DatabaseService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public DatabaseService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
        }

        private async Task _Init()
        {
            using var work = unitOfWorkFactory.Create();
            if (await work.Database.IsExistTables())
            {
                throw new Exception("Database initialization failed because table already exists.");
            }
            work.BeginTransaction();
            try
            {               
                await work.Database.CreateTables();
                // 创建管理员
                Account account = Account.Create("admin", "123456", Domain.Enums.RolesType.Admin);
                await work.Account.Insert(account);
                // 设置应用程序标识
                Config appIdConfig = Config.Create(ConfigKeyNames.AppId, Constants.AppId);
                await work.Config.Insert(appIdConfig);
                // 设置数据库版本
                Config dbVersionConfig = Config.Create(ConfigKeyNames.DbVersion, new Version(1, 0).ToString());
                await work.Config.Insert(dbVersionConfig);
                work.Commit();
            }
            catch (Exception)
            {
                work.Rollback();
                throw;
            }
        }

        /// <summary>
        /// 初始化数据库
        /// </summary>
        public void Init()
        {
            // 同步等待任务完成（阻塞当前线程）
            _Init().GetAwaiter().GetResult();
        }
    }
}
