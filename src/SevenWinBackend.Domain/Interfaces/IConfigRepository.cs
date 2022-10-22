﻿using SevenWinBackend.Domain.Common;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Interfaces
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
        /// <summary>
        /// 获取出7制胜配置
        /// </summary>
        public Task<SevenGameConfig> GetSevenGameConfig();
        /// <summary>
        /// 设置出7制胜配置
        /// </summary>
        public Task SetSevenGameConfig(SevenGameConfig sevenGameConfig);
    }
}
