using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Enums
{
    /// <summary>
    /// 配置键名
    /// </summary>
    public enum ConfigKeyNames
    {
        /// <summary>
        /// 无效配置
        /// </summary>
        None = 0,
        /// <summary>
        /// 应用程序标识
        /// </summary>
        AppId = 1,
        /// <summary>
        /// 数据库版本
        /// </summary>
        DbVersion = 2
    }
}
