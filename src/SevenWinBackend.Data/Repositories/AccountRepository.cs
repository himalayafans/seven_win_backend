using PetaPoco;
using SevenWinBackend.Application.Repositories;
using SevenWinBackend.Data.Base;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Data.Repositories
{
    internal class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(IDatabase db) : base(db)
        {
        }
        public override async Task Insert(Account entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new Exception("用户名不能为空");
            }
            var account = await GetByName(entity.Name);
            if (account != null)
            {
                throw new Exception("该用户名已存在");
            }
            await base.Insert(entity);
        }
        public override async Task Update(Account entity)
        {
            entity.UpdatedAt = DateTime.Now;
            await base.Update(entity);
        }

        /// <summary>
        /// 通过登录名获取账户
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Account?> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            name = name.Trim().ToLower();
            string sql = "select * from account where lower(name) = @Name;";
            return await this.Db.SingleOrDefaultAsync<Account?>(sql, new { Name = name });
        }
    }
}
