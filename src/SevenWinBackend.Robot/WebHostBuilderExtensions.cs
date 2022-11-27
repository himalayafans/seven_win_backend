using Discord.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Polly.Extensions.Http;
using Polly;
using Serilog;
using SevenWinBackend.Application.Data;
using SevenWinBackend.Application.Games.SevenWin;
using SevenWinBackend.Application.Interfaces;
using SevenWinBackend.Application.Options;
using SevenWinBackend.Application.Services;
using SevenWinBackend.Application.Services.Data;
using SevenWinBackend.Data;
using SevenWinBackend.OcrSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Robot
{
    internal static class WebHostBuilderExtensions
    {
        /// <summary>
        /// 增加机器人服务
        /// </summary>
        public static void AddRobot(this IServiceCollection services)
        {
            //services.AddHttpClient();
            services.AddHttpClient("HttpClient").AddPolicyHandler(GetRetryPolicy());
            services.TryAddSingleton<CommandService, CommandService>();
            services.TryAddSingleton<SettingOptions, SettingOptions>();
            services.TryAddSingleton<ImageHandlerService>();
            services.TryAddSingleton<IOcrService, OcrService>();
            services.TryAddSingleton<SevenWinGameEngine>();
            services.TryAddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
            services.TryAddSingleton<DiscordClientFactory, DiscordClientFactory>();
            services.TryAddSingleton<DiscordClientService, DiscordClientService>();
            services.TryAddSingleton<FileService, FileService>();
            services.TryAddSingleton<HttpService, HttpService>();
            services.TryAddSingleton<ChannelService, ChannelService>();
            services.TryAddSingleton<DatabaseService, DatabaseService>();
            services.TryAddSingleton<DataService, DataService>();
            services.TryAddSingleton<GuildService, GuildService>();
            services.TryAddSingleton<ImageService, ImageService>();
            services.TryAddSingleton<PlayerGameService, PlayerGameService>();
            services.TryAddSingleton<PlayerService, PlayerService>();
            services.TryAddSingleton<SevenWinRecordService, SevenWinRecordService>();
        }
        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            // 代码来源：https://briancaos.wordpress.com/2020/03/25/httpclient-retry-mechanism-with-net-core-polly-and-ihttpclientfactory/
            return HttpPolicyExtensions
              // Handle HttpRequestExceptions, 408 and 5xx status codes
              .HandleTransientHttpError()
              // Handle 404 not found
              .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
              // Handle 401 Unauthorized
              .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.Unauthorized)
              // What to do if any of the above erros occur:
              // Retry 3 times, each time wait 1,2 and 4 seconds before retrying.
              .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(2));
        }
    }
}
