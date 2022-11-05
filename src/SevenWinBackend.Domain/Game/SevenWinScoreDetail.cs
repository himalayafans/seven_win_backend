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
    public int PriceIncludesSevenTimes { get; set; }
    /// <summary>
    /// 价格包含7获得的积分（玉米）
    /// </summary>
    public int PriceScore { get; set; }
    /// <summary>
    /// 是否是7分发帖
    /// </summary>
    public bool IsSevenTime { get; set; }
    /// <summary>
    /// 7分发帖获得的玉米
    /// </summary>
    public int TimeScore { get; set; }
    /// <summary>
    /// 空频道ID（）
    /// </summary>
    public Guid EmptyChannelId { get; set; } = Guid.Empty;

    /// <summary>
    /// 获得积分总数
    /// </summary>
    /// <returns></returns>
    public int GetSumOfScore()
    {
        return TimeScore + PriceScore;
    }
}