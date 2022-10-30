using SevenWinBackend.Application.Base;
using SevenWinBackend.Domain.Common;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Repositories
{
    /// <summary>
    /// 应用配置存储库
    /// </summary>
    public interface IConfigRepository : IRepository<Config>
    {
        /// <summary>
        /// 获取数据库版本
        /// </summary>
        public Version GetDbVersion();
        /// <summary>
        /// 设置数据库版本
        /// </summary>
        public Task SetDbVersion(Version version);
        /// <summary>
        /// 获取应用程序标识
        /// </summary>
        public Task<string> GetAppId();
        /// <summary>
        /// 设置应用程序标识
        /// </summary>
        public Task SetAppId();
    }
}
