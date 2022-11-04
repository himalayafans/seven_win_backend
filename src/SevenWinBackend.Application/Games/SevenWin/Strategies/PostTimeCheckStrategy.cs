using SevenWinBackend.Application.Games.SevenWin.Core;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies;

/// <summary>
/// 发帖时间验证处理器
/// </summary>
internal class PostTimeCheckStrategy : BaseStrategy
{
    public override Task Handle(StrategyContext context)
    {
        // Discord发帖的分钟
        var minute = context.SocketUserMessage.CreatedAt.Minute;
        // 补充前导0， 例如 1 -> 01
        var timeString = minute.ToString().PadLeft(2, '0');
        // TODO 需要完善逻辑
        if (context.OcrResult == null)
        {
            throw new NullReferenceException();
        }
        else
        {
            if (context.OcrResult.GetText().Contains($":{timeString}"))
            {
                Successor?.Handle(context);
            }
            else
            {
                context.PlayResult.AddMessage("发帖时间与截图时间不一致");
            }
        }
        return Task.CompletedTask;
    }
}