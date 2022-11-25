using SevenWinBackend.Application.Games.SevenWin.Core;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies;

/// <summary>
/// 发帖时间策略（检查发帖时间与截图时间是否一致）
/// </summary>
internal class PostTimeCheckStrategy : BaseStrategy
{
    public override async Task Handle(StrategyContext context)
    {
        // Discord发帖的分钟
        var minute = context.SocketUserMessage.CreatedAt.Minute;
        // 补充前导0， 例如 1 -> 01
        var timeString = minute.ToString().PadLeft(2, '0');
        if (context.OcrResult == null)
        {
            throw new InvalidOperationException();
        }
        else
        {
            if (context.OcrResult.GetText().Contains($":{timeString}"))
            {
                await (this.Successor?.Handle(context) ?? Task.CompletedTask);
            }
            else
            {
                context.PlayResult.AddMessage("发帖时间与截图时间不一致");
            }
        }
    }
}