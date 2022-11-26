using Discord.Net.Rest;
using Discord;
using Discord.WebSocket;
using SevenWinBackend.Application.Interfaces;
using SevenWinBackend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SevenWinBackend.Application.Options;

namespace SevenWinBackend.Application.Services
{
    public class DiscordClientFactory
    {
        private readonly SettingOptions settings;

        public DiscordClientFactory(SettingOptions settings)
        {
            this.settings = settings;
        }

        public DiscordSocketClient Create()
        {
            DiscordSocketConfig config = new DiscordSocketConfig()
            {
                RestClientProvider = DefaultRestClientProvider.Create(useProxy: settings.EnableDiscordProxy),
                LogLevel = LogSeverity.Verbose,
                GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent
            };
            return new DiscordSocketClient(config);
        }
    }
}
