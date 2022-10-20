using SevenWinBackend.Domain.Base;
using SevenWinBackend.Domain.Enums;

namespace SevenWinBackend.Domain.Entities;

/// <summary>
/// 玩家游戏视图
/// </summary>
public class PlayerGameView: BaseView
{
    /// <summary>
    /// 玩家ID
    /// </summary>
    public Guid PlayerId { get; set; }
    
    /// <summary>
    /// 变动的积分（玉米小计）(明细在Content属性)
    /// </summary>
    public decimal Score { get; set; } = 0;
    
    /// <summary>
    /// 游戏类型
    /// </summary>
    public GameTypes Type { get; set; } = GameTypes.None;
    
    /// <summary>
    /// 游戏内容（IGame对象序列化后的JSON）
    /// </summary>
    public string Content { get; set; } = String.Empty;

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedAt  { get; set; } = DateTime.Now;

    /// <summary>
    /// 玩家Discord名称
    /// </summary>
    public string PlayerDisplayName { get; set; } = String.Empty;

    /// <summary>
    /// 玩家Discord标识符
    /// </summary>
    public string PlayerDiscriminator { get; set; } = String.Empty;

    /// <summary>
    /// 玩家头像ID
    /// </summary>
    public string PlayerAvatarId { get; set; } = String.Empty;

    /// <summary>
    /// 玩家状态（启用或禁用）
    /// </summary>
    public PlayerStatus PlayerStatus { get; set; } = PlayerStatus.Enable;

    /// <summary>
    /// discord服务器ID
    /// </summary>
    public ulong GuildDiscordId { get; set; }

    /// <summary>
    /// Discord服务器名称
    /// </summary>
    public string GuildName { get; set; } = String.Empty;
    
    /// <summary>
    /// discord频道ID
    /// </summary>
    public ulong ChannelDiscordId { get; set; }

    /// <summary>
    /// Discord频道名称
    /// </summary>
    public string ChannelName { get; set; } = String.Empty;
}