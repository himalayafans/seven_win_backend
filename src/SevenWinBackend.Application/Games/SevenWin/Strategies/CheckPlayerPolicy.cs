using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using SevenWinBackend.Application.Games.SevenWin.Core;
using SevenWinBackend.Application.Services.Data;
using SevenWinBackend.Domain.Entities;
using SevenWinBackend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies
{
    /// <summary>
    /// 玩家检查策略
    /// </summary>
    internal class CheckPlayerPolicy : BaseStrategy
    {
        public override async Task Handle(StrategyContext context)
        {
            var services = context.ServiceProvider;
            var playerService = services.GetRequiredService<PlayerService>();
            var author = context.SocketUserMessage.Author as SocketGuildUser;
            if (author != null && !author.IsBot)
            {
                var player = await playerService.GetOrAdd(author);
                context.Cache.PlayerId = player.Id;
                switch (player.Status)
                {
                    case PlayerStatus.Enable:
                        {
                            await (Successor?.Handle(context) ?? Task.CompletedTask);
                            break;
                        }
                    case PlayerStatus.Disable:
                        context.PlayResult.AddMessage("该账户不能参加游戏，请联系管理员");
                        break;
                    default:
                        // 忽略其他状态
                        break;
                }
            }
        }
    }
}