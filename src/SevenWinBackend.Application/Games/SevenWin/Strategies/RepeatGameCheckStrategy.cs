using Microsoft.Extensions.DependencyInjection;
using SevenWinBackend.Application.Games.SevenWin.Core;
using SevenWinBackend.Application.Services.Data;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies;

internal class RepeatGameCheckStrategy : BaseStrategy
{
    public override async Task Handle(StrategyContext context)
    {
        string userDiscordId = context.SocketUserMessage.Author.Id.ToString();
        string channelDiscordId = context.SocketUserMessage.Channel.Id.ToString();
        SevenWinGameService sevenWinGameService = context.ServiceProvider.GetRequiredService<SevenWinGameService>();
        var baseRecord = await sevenWinGameService.GetBaseGameInOneMinute(userDiscordId);
        // TODO 待完善
        if (baseRecord != null)
        {

        }
    }
}