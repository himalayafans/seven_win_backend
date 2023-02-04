using SevenWinBackend.Application.Data;
using SevenWinBackend.Domain.Common;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Services.Data
{
    public class AccountService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public AccountService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
        }
        /// <summary>
        /// 账号注册
        /// </summary>
        public async Task<Account> Register(string name, string password)
        {
            using var work = unitOfWorkFactory.Create();
            Account? account = await work.Account.GetByName(name);
            if (account != null)
            {
                throw new HttpResponseException("该账号已存在");
            }
            account = Account.Create(name.Trim().ToLower(), password.Trim());
            await work.Account.Insert(account);
            return account;
        }
        /// <summary>
        /// 账号登录
        /// </summary>
        public async Task<Account> Login(string name, string password)
        {
            using var work = unitOfWorkFactory.Create();
            Account? account = await work.Account.GetByName(name);
            string msg = "账号或密码错误";
            if (account == null)
            {
                throw new HttpResponseException(msg);
            }
            if (!account.VerifyPassword(password.Trim()))
            {
                throw new HttpResponseException(msg);
            }
            return account;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        public async Task ModifyPassword(Guid id, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password), "新密码不能为空");
            }
            using var work = unitOfWorkFactory.Create();
            Account? account = await work.Account.GetById(id);
            if (account == null)
            {
                throw new HttpResponseException("该账号不存在");
            }
            account.ModifyPassword(password.Trim());
            await work.Account.Update(account);
        }
        /// <summary>
        /// 获取除管理员的所有账号
        /// </summary>
        public async Task<List<Account>> GetAccounts()
        {
            using var work = unitOfWorkFactory.Create();
            return await work.Account.GetAccounts();
        }
    }
}
