using SevenWinBackend.Common;
using SevenWinBackend.Domain.Base;
using SevenWinBackend.Domain.Enums;
using SevenWinBackend.Domain.Interfaces;

namespace SevenWinBackend.Domain.Entities;

/***************************************
 * 该表只记录游戏的分数
 * 因为可能以后的游戏可能是文字类的游戏，不包含图片
 * 游戏的图片将保存在单独游戏流程的表中
 ***************************************/

/// <summary>
/// 玩家参与的游戏
/// </summary>
public class PlayerGame : BaseEntity
{
    /// <summary>
    /// 玩家ID
    /// </summary>
    public Guid PlayerId { get; set; }
    /// <summary>
    /// 本次游戏获得的玉米小计(明细在ScoreDetail属性)
    /// </summary>
    public int Score { get; set; } = 0;
    /// <summary>
    /// 游戏类型
    /// </summary>
    public GameTypes GameType { get; set; } = GameTypes.None;
    /// <summary>
    /// 积分详情（IScoreDetail对象序列化后的JSON）
    /// </summary>
    public string ScoreDetail { get; set; } = string.Empty;
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedAt { get; set; }
    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// 创建玩家游戏
    /// </summary>
    /// <param name="playerId">玩家ID</param>
    /// <param name="score">积分小计</param>
    /// <param name="type">游戏类型</param>
    /// <param name="scoreDetail">积分明细</param>
    public static PlayerGame Create(Guid playerId, int score, GameTypes type, IScoreDetail scoreDetail)
    {
        if (playerId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(playerId));
        }
        if (scoreDetail == null)
        {
            throw new ArgumentNullException(nameof(scoreDetail));
        }
        if (type == GameTypes.None)
        {
            throw new ArgumentNullException(nameof(type));
        }
        DateTime now = DateTime.Now;
        return new PlayerGame()
        {
            Id = Guid.NewGuid(),
            PlayerId = playerId,
            Score = score,
            GameType = type,
            ScoreDetail = JsonHelper.Serialize(scoreDetail),
            CreatedAt = now,
            UpdatedAt = now
        };
    }
    /// <summary>
    /// 设置积分明细
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public void SetScoreDetail(IScoreDetail scoreDetail)
    {
        if (scoreDetail == null)
        {
            throw new ArgumentNullException(nameof(scoreDetail));
        }
        this.ScoreDetail = JsonHelper.Serialize(scoreDetail);
        this.UpdatedAt = DateTime.Now;
    }
}