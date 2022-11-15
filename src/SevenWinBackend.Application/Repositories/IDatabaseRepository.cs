using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Repositories
{
    public interface IDatabaseRepository
    {
        /// <summary>
        /// 是否存在数据表
        /// </summary>
        /// <returns></returns>
        public Task<bool> IsExistTables();
        /// <summary>
        /// 创建数据表
        /// </summary>
        public Task CreateTables();
        /// <summary>
        /// 删除数据表
        /// </summary>
        public Task DeleteTables();
        /// <summary>
        /// 升级数据表
        /// </summary>
        public Task UpdateTables(Version version);
        /// <summary>
        /// 删除所有数据
        /// </summary>
        public Task ClearData();
    }
}
