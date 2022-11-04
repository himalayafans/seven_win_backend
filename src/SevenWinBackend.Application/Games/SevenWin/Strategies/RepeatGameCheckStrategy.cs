using Microsoft.Extensions.DependencyInjection;
using SevenWinBackend.Application.Games.SevenWin.Core;
using SevenWinBackend.Application.Services.Data;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies;

internal class RepeatGameCheckStrategy : BaseStrategy
{
    public override async Task Handle(StrategyContext context)
    {
        var userDiscordId = context.SocketUserMessage.Author.Id;
        var channelDiscordId = context.SocketUserMessage.Channel.Id;
        SevenWinGameService sevenWinGameService = context.ServiceProvider.GetRequiredService<SevenWinGameService>();
        var baseRecord = await sevenWinGameService.GetBaseGameInOneMinute(userDiscordId);

        if (baseRecord != null)
        {

        }
    }
}