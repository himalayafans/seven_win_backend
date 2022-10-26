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
        //string priceText = context.OcrResult.GetPrice();
        //var count = priceText.ToCharArray().Count(p => p == '7');
        //// 如果价格包含7
        //if (count >= 1)
        //{
        //    var score = GetScore(count);
        //    result.TotalScore = result.TotalScore + score;
        //    result.SevenTimes = count;
        //    result.AddMessage($"喜币价格{price}包含{count}个7，获得{score}个玉米");
        //}
        //else
        //{
        //    result.AddMessage($"喜币价格{price},没有包含7");
        //}
    }
}