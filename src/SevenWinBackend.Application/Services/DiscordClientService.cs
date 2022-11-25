using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using SevenWinBackend.Application.Common;
using SevenWinBackend.Application.Games.SevenWin;
using SevenWinBackend.Application.Options;
using SevenWinBackend.Application.Services.Data;
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
        private readonly SettingOptions settings;
        private readonly SevenWinGameEngine sevenWinGameEngine;
        private readonly DataService dataService;

        public DiscordClientService(DiscordClientFactory factory, ILogger<DiscordClientService> logger, CommandService commandService, SettingOptions appSettings, SevenWinGameEngine sevenWinGameEngine, DataService dataService)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.sevenWinGameEngine = sevenWinGameEngine ?? throw new ArgumentNullException(nameof(sevenWinGameEngine));
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            this.client = factory.Create();
            this.commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            this.commandService.Log += CommandService_Log;
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
            logger.LogInformation($"[Discord] ${arg.ToString()}");
            return Task.CompletedTask;
        }

        private Task Client_Log(Discord.LogMessage arg)
        {
            logger.LogInformation($"[Discord] ${arg.ToString()}");
            return Task.CompletedTask;
        }

        private async Task Client_MessageReceived(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            if (message == null)
            {
                logger.LogInformation("Ignore system messages");
                // 忽略系统消息
                return;
            }
            if (message.Author.IsBot)
            {
                logger.LogInformation("Ignore messages from bots.");
                // 忽略机器人消息
                return;
            }
            var user = message.Author as SocketGuildUser;
            if (user == null)
            {
                logger.LogInformation("Ignore users who are not SocketGuildUser.");
                return;
            }
            var channel = message.Channel as SocketGuildChannel;
            if (channel == null)
            {
                return;
            }
            PlayResult result = new PlayResult();
            await sevenWinGameEngine.Handle(message, channel, user, result);
            string replyMessage = result.ToString();
            if (!string.IsNullOrWhiteSpace(result.ToString()))
            {
                await message.ReplyAsync(replyMessage);
            }
        }

        private async Task Client_Ready()
        {
            this.logger.LogInformation("[Discord] Client Ready.");
            await this.dataService.Fill(this.client);
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}