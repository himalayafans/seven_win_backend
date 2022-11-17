using SevenWinBackend.Application.Data;
using SevenWinBackend.Common;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace SevenWinBackend.DataTests
{
    [Collection("Database collection")]
    public class AccountTests : IDisposable
    {
        private readonly DatabaseFixture fixture;
        private readonly ITestOutputHelper output;

        public AccountTests(DatabaseFixture fixture, ITestOutputHelper output)
        {
            this.fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
            this.output = output ?? throw new ArgumentNullException(nameof(output));
        }
        [Fact]
        public async Task InsertTest()
        {
            string password = "123";
            Account account = Account.Create("admin", password, Domain.Enums.RolesType.Admin);
            using var db = fixture.unitOfWorkFactory.Create();
            output.WriteLine($"插入account id:{account.Id}");
            await db.Account.Insert(account);
            var dbValue = await db.Account.GetByName(account.Name);
            if (dbValue == null)
            {
                throw new Exception("获取用户为空");
            }
            Assert.Equal(account.Id, dbValue.Id);
            Assert.Equal(account.PasswordHash, password.ToSha256Hash());
            Assert.Equal(Domain.Enums.RolesType.Admin, dbValue.Role);
        }

        async Task Clear()
        {
            using var db = fixture.unitOfWorkFactory.Create();
            var account = await db.Account.GetByName("admin");
            if (account != null)
            {
                output.WriteLine($"删除account id:{account.Id}");
                await db.Account.Delete(account.Id);
            }
        }

        public void Dispose()
        {
            Clear().GetAwaiter().GetResult();
        }
    }
}
