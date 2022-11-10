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
using SevenWinBackend.Application.Common;

namespace SevenWinBackend.Application.Services
{
    public class DiscordClientFactory : IDiscordClientFactory
    {
        private readonly OptionSettings settings;

        public DiscordClientFactory(OptionSettings settings)
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
