using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Data
{
    /// <summary>
    /// 数据库接口
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// 添加种子数据
        /// </summary>
        Task Seed();
        /// <summary>
        /// 升级数据库
        /// </summary>
        Task Update();
    }
}
