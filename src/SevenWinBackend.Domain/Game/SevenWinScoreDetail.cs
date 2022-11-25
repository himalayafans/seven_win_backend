using SevenWinBackend.Domain.Interfaces;

namespace SevenWinBackend.Domain.Game;

/// <summary>
/// 出7制胜积分明细
/// </summary>
public class SevenWinScoreDetail : IScoreDetail
{
    /// <summary>
    /// 喜币价格
    /// </summary>
    public string Price { get; set; } = string.Empty;
    /// <summary>
    /// 价格包含7的次数
    /// </summary>
    public int PriceIncludesSevenTimes { get; set; } = 0;
    /// <summary>
    /// 价格包含7获得的积分（玉米）
    /// </summary>
    public int PriceScore { get; set; } = 0;
    /// <summary>
    /// 是否是7分发帖
    /// </summary>
    public bool IsSevenTime { get; set; } = false;
    /// <summary>
    /// 7分发帖获得的玉米
    /// </summary>
    public int TimeScore { get; set; } = 0;
    /// <summary>
    /// 空频道ID（）
    /// </summary>
    public Guid EmptyChannelId { get; set; } = Guid.Empty;
    /// <summary>
    /// 附加积分
    /// </summary>
    public int AdditionalScore { get; set; } = 0;

    public static SevenWinScoreDetail Create(string price, int priceIncludesSevenTimes, int priceScore, bool isSevenTime, int timeScore, Guid emptyChannelId)
    {
        return new SevenWinScoreDetail()
        {
            Price = price,
            PriceIncludesSevenTimes = priceIncludesSevenTimes,
            PriceScore = priceScore,
            IsSevenTime = isSevenTime,
            TimeScore = timeScore,
            EmptyChannelId = emptyChannelId
        };
    }


    /// <summary>
    /// 获得积分总数
    /// </summary>
    /// <returns></returns>
    public int GetSumOfScore()
    {
        return TimeScore + PriceScore + AdditionalScore;
    }
}