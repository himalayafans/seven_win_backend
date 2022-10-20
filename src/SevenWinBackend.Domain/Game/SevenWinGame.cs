using SevenWinBackend.Domain.Interfaces;

namespace SevenWinBackend.Domain.Game;

/// <summary>
/// 出7制胜游戏
/// </summary>
public class SevenWinGame: IGame
{
    /// <summary>
    /// 价格包含7的次数
    /// </summary>
    public int PriceIncludesSevenTimes { get; set; }
    /// <summary>
    /// 价格包含7获得的积分（玉米）
    /// </summary>
    public int PriceIncludesSevenScore { get; set; }
    /// <summary>
    /// 是否是7分发帖
    /// </summary>
    public bool IsSevenTime { get; set; }
    /// <summary>
    /// 7分发帖获得的玉米
    /// </summary>
    public int SevenTimeScore { get; set; }
}