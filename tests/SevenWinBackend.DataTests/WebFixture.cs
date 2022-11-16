using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SevenWinBackend.Application.Common;
using SevenWinBackend.Application.Data;
using SevenWinBackend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.DataTests
{
    public class WebFixture
    {
        internal readonly WebApplication application;
        public WebFixture()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddHttpClient();
            builder.Services.TryAddSingleton<OptionSettings, OptionSettings>();
            builder.Services.TryAddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
            application = builder.Build();
        }
    }
}
