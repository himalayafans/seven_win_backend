using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SevenWinBackend.Application.Data;
using SevenWinBackend.Application.Options;
using SevenWinBackend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace SevenWinBackend.DataTests
{
    public class DatabaseFixture : IDisposable
    {
        public readonly WebApplication application;
        public readonly IUnitOfWorkFactory unitOfWorkFactory;
        internal async Task Seed(IUnitOfWorkFactory factory)
        {
            using var db = factory.Create();
            await db.Database.CreateTables();
        }

        public DatabaseFixture()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddHttpClient();
            builder.Services.TryAddSingleton<SettingOptions, SettingOptions>();
            builder.Services.TryAddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
            application = builder.Build();
            unitOfWorkFactory = application.Services.GetRequiredService<IUnitOfWorkFactory>();
            Seed(unitOfWorkFactory).GetAwaiter().GetResult();
        }

        public void Dispose()
        {
            using var db = unitOfWorkFactory.Create();          
            db.Database.DeleteTables().GetAwaiter().GetResult();
        }
    }
}
