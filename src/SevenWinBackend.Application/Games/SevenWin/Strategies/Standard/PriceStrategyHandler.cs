using System.Globalization;
using SevenWinBackend.Application.Games.SevenWin.Base;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies.Standard;

/// <summary>
/// 价格策略处理器
/// </summary>
internal class PriceStrategyHandler : BaseStrategyHandler
{
    /// <summary>
    /// 获取奖励玉米
    /// </summary>
    private static int GetScore(int count)
    {
        return count switch
        {
            1 => 7,
            2 => 77,
            3 => 777,
            4 => 7777,
            5 => 77777,
            6 => 777777,
            7 => 7777777,
            _ => throw new Exception($"规则不支持价格含{count}个7")
        };
    }

    public override void Handle(StandardStrategyContext context)
    {
        throw new NotImplementedException();
    }
}