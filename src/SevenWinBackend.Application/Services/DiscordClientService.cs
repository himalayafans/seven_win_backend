using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using SevenWinBackend.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Services
{
    /// <summary>
    /// Discord客户端服务
    /// </summary>
    public class DiscordClientService : IDisposable
    {
        protected readonly DiscordSocketClient client;
        protected readonly DiscordClientFactory factory;
        private readonly ILogger<DiscordClientService> logger;
        private readonly CommandService commandService;
        private readonly AppSettings settings;

        public DiscordClientService(DiscordClientFactory factory, ILogger<DiscordClientService> logger, CommandService commandService, AppSettings appSettings)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
            this.client = factory.Create();
            this.commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            this.commandService.Log += CommandService_Log;
            this.logger = logger;
            this.settings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
            this.client.Ready += Client_Ready;
            this.client.MessageReceived += Client_MessageReceived;
            this.client.Log += Client_Log;
            this.commandService.CommandExecuted += CommandService_CommandExecuted;
        }

        public async Task LoginAsync()
        {
            await client.LoginAsync(TokenType.Bot, this.settings.DiscordToken);
        }

        public async Task StartAsync()
        {
            await client.StartAsync();
        }

        private Task CommandService_CommandExecuted(Discord.Optional<CommandInfo> arg1, ICommandContext arg2, IResult arg3)
        {
            return Task.CompletedTask;
        }

        private Task CommandService_Log(Discord.LogMessage arg)
        {
            logger.LogInformation(arg.ToString());
            return Task.CompletedTask;
        }

        private Task Client_Log(Discord.LogMessage arg)
        {
            logger.LogInformation(arg.ToString());
            return Task.CompletedTask;
        }

        private Task Client_MessageReceived(SocketMessage arg)
        {
            
        }

        private Task Client_Ready()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}