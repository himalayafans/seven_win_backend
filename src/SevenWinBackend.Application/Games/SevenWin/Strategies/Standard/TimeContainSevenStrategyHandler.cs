using SevenWinBackend.Application.Games.SevenWin.Base;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies.Standard;

/// <summary>
/// 时间包含7策略处理器
/// </summary>
internal class TimeContainSevenStrategyHandler : BaseStrategyHandler
{
    ///// <summary>
    ///// 是否满足时间规则
    ///// </summary>
    //private static bool IsEnabled(PlayResult result)
    //{
    //    // Discord发帖的分钟数
    //    var minute = result.SocketUserMessage.CreatedAt.Minute;
    //    // 获取分钟数的最后一位，例如 57 得到 7
    //    var lastNum = minute.ToString().ToCharArray().Last();
    //    // 末尾字符必须是7
    //    return lastNum == '7';
    //}
    //public override void Handle(PlayResult result)
    //{
    //    // 如果该基本条件没满足，则短路，不调用后继者
    //    if (!IsEnabled(result))
    //    {
    //        result.AddMessage("发帖时间的尾数不是7");
    //        return;
    //    }
    //    const int score = 77;
    //    result.TotalScore = result.TotalScore + score;
    //    result.AddMessage($"发帖时间尾数是7，获得{score}个玉米");
    //    // 调用后继者
    //    Successor?.Handle(result);
    //}
    public override void Handle(StandardStrategyContext context)
    {
        throw new NotImplementedException();
    }
}