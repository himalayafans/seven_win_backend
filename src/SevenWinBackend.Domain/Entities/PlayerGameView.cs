using SevenWinBackend.Domain.Base;
using SevenWinBackend.Domain.Enums;

namespace SevenWinBackend.Domain.Entities;

/// <summary>
/// 玩家游戏视图
/// </summary>
public class PlayerGameView : BaseView
{
    /// <summary>
    /// 玩家ID
    /// </summary>
    public Guid PlayerId { get; set; }
    /// <summary>
    /// 本次游戏获得的玉米小计(明细在ScoreDetail属性)
    /// </summary>
    public decimal Score { get; set; }
    /// <summary>
    /// 游戏类型
    /// </summary>
    public GameTypes Type { get; set; } = GameTypes.None;
    /// <summary>
    /// 积分详情（IScoreDetail对象序列化后的JSON）
    /// </summary>
    public string ScoreDetail { get; set; } = string.Empty;
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedAt { get; set; }
    /// <summary>
    /// 玩家discord ID
    /// </summary>
    public ulong PlayerDiscordId { get; set; }
    /// <summary>
    /// 玩家Discord 名称
    /// </summary>
    public string PlayerDisplayName { get; set; } = String.Empty;
    /// <summary>
    /// Discord标识符（4位数字,有前导0，因此不能用int）
    /// </summary>
    public string PlayerDiscriminator { get; set; } = String.Empty;
    /// <summary>
    /// 头像ID
    /// </summary>
    public string PlayerAvatarId { get; set; } = String.Empty;
    /// <summary>
    /// 状态（启用或禁用）
    /// </summary>
    public PlayerStatus PlayerStatus { get; set; }
}