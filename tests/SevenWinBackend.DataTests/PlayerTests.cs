using SevenWinBackend.Application.Common;
using SevenWinBackend.Application.Data;
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
    public class PlayerTests : IDisposable
    {
        private readonly DatabaseFixture fixture;
        private readonly ITestOutputHelper output;
        private readonly IUnitOfWorkFactory factory;
        private readonly List<Player> players = new List<Player>();
        public PlayerTests(DatabaseFixture fixture, ITestOutputHelper output)
        {
            this.fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
            this.output = output ?? throw new ArgumentNullException(nameof(output));
            this.factory = fixture.unitOfWorkFactory;
            for (int i = 0; i < 45; i++)
            {
                Random rnd = new Random();
                string discordId = rnd.Next(10000, 99999).ToString();
                players.Add(Player.Create(discordId, $"user{discordId}", "8888", ""));
            }
            this.Insert().GetAwaiter().GetResult();
        }

        private async Task Insert()
        {
            using var db = factory.Create();
            db.BeginTransaction();
            try
            {
                foreach (var item in players)
                {
                    await db.Player.Insert(item);
                }
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 测试第一页
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestOnePage()
        {
            using var db = factory.Create();
            var options = new QueryOptions();
            var result = await db.Player.Search(options);
            Assert.Equal(players.Count, result.RowCount);
            Assert.Equal(5, result.PageCount);
            Assert.Equal(result.PageSize, result.Data.Count);
        }
        /// <summary>
        /// 测试最后一页
        /// </summary>
        [Fact]
        public async Task TestLastPage()
        {
            using var db = factory.Create();
            var options = new QueryOptions();
            options.Page = 5;
            var result = await db.Player.Search(options);
            Assert.Equal(5, result.PageCount);
            Assert.Equal(5, result.Data.Count);
        }
       

        private async Task Clear()
        {
            using var db = factory.Create();
            db.BeginTransaction();
            try
            {
                foreach (var item in players)
                {
                    await db.Player.Delete(item.Id);
                }
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }

        public void Dispose()
        {
            Clear().GetAwaiter().GetResult();
        }
    }
}
