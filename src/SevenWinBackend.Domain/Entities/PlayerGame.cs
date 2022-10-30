using SevenWinBackend.Common;
using SevenWinBackend.Domain.Base;
using SevenWinBackend.Domain.Enums;
using SevenWinBackend.Domain.Interfaces;

namespace SevenWinBackend.Domain.Entities;

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
    public int Score { get; set; }
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
    /// 玩家参与的游戏(禁止代码中调用)
    /// </summary>
    public PlayerGame()
    {
    }

    /// <summary>
    /// 玩家参与的游戏
    /// </summary>
    /// <param name="playerId">玩家ID</param>
    /// <param name="score">积分小计</param>
    /// <param name="type">游戏类型</param>
    /// <param name="game">游戏</param>
    public PlayerGame(Guid playerId,int score, GameTypes type, IScoreDetail game)
    {
        DateTime now = DateTime.Now;
        Id = Guid.NewGuid();
        PlayerId = playerId;
        Score = score;
        GameType = type;
        ScoreDetail = JsonHelper.Serialize(game);
        CreatedAt = now;
        UpdatedAt = now;
    }
}