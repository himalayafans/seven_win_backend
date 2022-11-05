/**************************
 * 每个Game包含获取积分（玉米）的明细
 *************************/

namespace SevenWinBackend.Domain.Interfaces;

/// <summary>
/// 游戏积分明细接口（空接口）
/// </summary>
public interface IScoreDetail
{
    /// <summary>
    /// 获得积分总数
    /// </summary>
    public int GetSumOfScore();
}