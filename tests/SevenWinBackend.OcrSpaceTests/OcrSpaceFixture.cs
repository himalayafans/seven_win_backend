using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using SevenWinBackend.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SevenWinBackend.Application.Services;
using SevenWinBackend.OcrSpace;
using Microsoft.AspNetCore.Hosting;
using SevenWinBackend.Application.Options;

namespace SevenWinBackend.OcrSpaceTests
{
    public class OcrSpaceFixture
    {
        public readonly WebApplication application;
        public readonly SettingOptions settings;
        public readonly IOcrService ocrService;
        public readonly IHttpClientFactory httpClientFactory;
        public readonly IWebHostEnvironment env;
        public OcrSpaceFixture()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddHttpClient();
            builder.Services.TryAddSingleton<SettingOptions, SettingOptions>();
            builder.Services.TryAddSingleton<IOcrService, OcrService>();
            application = builder.Build();
            this.settings = application.Services.GetRequiredService<SettingOptions>();
            this.ocrService = application.Services.GetRequiredService<IOcrService>();
            this.httpClientFactory = application.Services.GetRequiredService<IHttpClientFactory>();
            this.env = application.Services.GetRequiredService<IWebHostEnvironment>();
        }
    }
}
