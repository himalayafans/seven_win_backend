using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SevenWinBackend.Application.Options;
using SevenWinBackend.Application.Services;

namespace SevenWinBackend.ApplicationTests
{
    public class AppFixture
    {
        public readonly IImageHandlerService imageService;
        public readonly WebApplication application;
        public readonly IWebHostEnvironment env;
        public AppFixture()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.TryAddSingleton<SettingOptions, SettingOptions>();
            builder.Services.TryAddSingleton<IImageHandlerService, ImageHandlerService>();
            application = builder.Build();
            this.imageService = application.Services.GetRequiredService<IImageHandlerService>();
            this.env = application.Services.GetRequiredService<IWebHostEnvironment>();
        }
    }
}
