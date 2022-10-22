using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Interfaces
{
    /// <summary>
    /// 账户存储库
    /// </summary>
    public interface IAccountRepository: IRepository<Account>
    {
        Task<Account?> GetByNameAsync(string name);
    }
}
