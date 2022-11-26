using Discord.Commands;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SevenWinBackend.Application.Interfaces;
using SevenWinBackend.Application.Options;
using SevenWinBackend.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Robot
{
    public class RobotWorker : IHostedService
    {
        private readonly ILogger<RobotWorker> logger;
        private readonly DiscordClientService clientService;

        public RobotWorker(ILogger<RobotWorker> logger, DiscordClientService clientService, SettingOptions options, IHostEnvironment env)
        {
            this.logger = logger;
            this.clientService = clientService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("await clientService.LoginAsync();");
            await clientService.LoginAsync();
            logger.LogInformation("await clientService.StartAsync();");
            await clientService.StartAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            clientService.Dispose();
            return Task.CompletedTask;
        }
    }
}
