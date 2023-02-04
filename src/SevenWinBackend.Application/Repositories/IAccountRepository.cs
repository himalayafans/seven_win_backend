using SevenWinBackend.Application.Base;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Repositories
{
    /// <summary>
    /// 账户存储库
    /// </summary>
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account?> GetByName(string name);
        /// <summary>
        /// 获取除管理员的所有账号
        /// </summary>
        Task<List<Account>> GetAccounts();
    }
}
