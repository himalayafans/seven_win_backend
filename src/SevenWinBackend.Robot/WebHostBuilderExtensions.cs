using Discord.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
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
            services.AddHttpClient();
            services.TryAddSingleton<CommandService, CommandService>();
            services.TryAddSingleton<SettingOptions, SettingOptions>();
            services.TryAddSingleton<IImageHandlerService, ImageHandlerService>();
            services.TryAddSingleton<IOcrService, OcrService>();
            services.TryAddSingleton<SevenWinGameEngine>();
            services.TryAddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
            services.TryAddSingleton<DiscordClientFactory, DiscordClientFactory>();
            services.TryAddSingleton<DiscordClientService, DiscordClientService>();
            services.TryAddSingleton<FileService, FileService>();
            services.TryAddSingleton<HttpService, HttpService>();
            services.TryAddSingleton<IImageHandlerService, ImageHandlerService>();
            services.TryAddSingleton<ChannelService, ChannelService>();
            services.TryAddSingleton<DatabaseService, DatabaseService>();
            services.TryAddSingleton<DataService, DataService>();
            services.TryAddSingleton<GuildService, GuildService>();
            services.TryAddSingleton<ImageService, ImageService>();
            services.TryAddSingleton<PlayerGameService, PlayerGameService>();
            services.TryAddSingleton<PlayerService, PlayerService>();
            services.TryAddSingleton<SevenWinRecordService, SevenWinRecordService>();
        }
    }
}
