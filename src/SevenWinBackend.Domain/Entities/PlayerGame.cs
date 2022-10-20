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
    /// 变动的积分（玉米小计）(明细在Content属性)
    /// </summary>
    public decimal Score { get; set; }

    /// <summary>
    /// 游戏类型
    /// </summary>
    public GameTypes Type { get; set; }

    /// <summary>
    /// 游戏内容（IGame对象序列化后的JSON）
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// 玩家参与的游戏(禁止代码中调用)
    /// </summary>
    public PlayerGame()
    {
        Content = string.Empty;
        CreatedAt = DateTime.MinValue;
    }

    /// <summary>
    /// 玩家参与的游戏
    /// </summary>
    /// <param name="playerId">玩家ID</param>
    /// <param name="score">积分小计</param>
    /// <param name="type">游戏类型</param>
    /// <param name="game">游戏</param>
    public PlayerGame(Guid playerId, decimal score, GameTypes type, IGame game)
    {
        Id = Guid.NewGuid();
        PlayerId = playerId;
        Score = score;
        Type = type;
        Content = JsonHelper.Serialize(game);
        CreatedAt = DateTime.Now;
    }
}