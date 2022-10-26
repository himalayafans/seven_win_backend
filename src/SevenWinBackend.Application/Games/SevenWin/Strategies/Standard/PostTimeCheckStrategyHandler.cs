using SevenWinBackend.Application.Games.SevenWin;
using SevenWinBackend.Application.Games.SevenWin.Base;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies.Standard;

/// <summary>
/// 发帖时间验证处理器
/// </summary>
internal class PostTimeCheckStrategyHandler : BaseStrategyHandler
{
    public override void Handle(StandardStrategyContext context)
    {
        // Discord发帖的分钟
        var minute = context.SocketUserMessage.CreatedAt.Minute;
        // 补充前导0， 例如 1 -> 01
        var timeString = minute.ToString().PadLeft(2, '0');
        if (context.OcrResult.GetText().Contains(timeString))
        {
            Successor?.Handle(context);
        }
        else
        {
            context.PlayResult.AddMessage("发帖时间与截图时间不一致");
        }
    }
}
