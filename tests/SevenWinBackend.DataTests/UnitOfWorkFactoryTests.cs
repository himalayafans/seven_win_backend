using Microsoft.Extensions.DependencyInjection;
using SevenWinBackend.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SevenWinBackend.DataTests
{
    public class UnitOfWorkFactoryTests : IClassFixture<WebFixture>, IDisposable
    {
        private readonly WebFixture webFixture;
        private readonly IUnitOfWorkFactory factory;

        public UnitOfWorkFactoryTests(WebFixture webFixture)
        {
            this.webFixture = webFixture;
            this.factory = webFixture.application.Services.GetRequiredService<IUnitOfWorkFactory>();
        }
        [Fact]
        public async Task CreateTablesTest()
        {
            using var db = factory.Create();
            await db.Database.CreateTables();
            var isExist = await db.Database.IsExistTables();
            Assert.True(isExist);
        }

        public void Dispose()
        {
            Task.Run(async () =>
            {
                var db = factory.Create();
                await db.Database.ClearData();
                await db.Database.DeleteTables();
            });
        }
    }
}
