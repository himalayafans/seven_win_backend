using SevenWinBackend.Domain.Base;
using SevenWinBackend.Domain.Enums;

namespace SevenWinBackend.Domain.Entities;

/// <summary>
/// 玩家
/// </summary>
public class Player : BaseEntity
{
    /// <summary>
    /// discord ID
    /// </summary>
    public ulong DiscordId { get; set; }

    /// <summary>
    /// Discord 名称
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// Discord标识符（4位数字,有前导0，因此不能用int）
    /// </summary>
    public string Discriminator { get; set; }

    /// <summary>
    /// 头像ID
    /// </summary>
    public string AvatarId { get; set; }

    /// <summary>
    /// 积分总数（即玉米数）
    /// </summary>
    public decimal Score { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// 修改时间
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// 状态（启用或禁用）
    /// </summary>
    public PlayerStatus Status { get; set; }

    /// <summary>
    /// 玩家(禁止代码中调用)
    /// </summary>
    public Player()
    {
        DisplayName = String.Empty;
        Discriminator = String.Empty;
        AvatarId = String.Empty;
        Score = 0;
        CreatedAt = DateTime.MinValue;
        UpdatedAt = DateTime.MinValue;
        Status = PlayerStatus.Disable;
    }
    /// <summary>
    /// 玩家
    /// </summary>
    /// <param name="discordId">discord ID</param>
    /// <param name="displayName">Discord 名称</param>
    /// <param name="discriminator">Discord标识符（4位数字）</param>
    /// <param name="avatarId">Discord头像ID</param>
    public Player(ulong discordId, string displayName, string discriminator, string avatarId)
    {
        if (discordId == 0)
        {
            throw new ArgumentException(nameof(discordId));
        }
        if (string.IsNullOrWhiteSpace(displayName))
        {
            throw new ArgumentException(nameof(displayName));
        }
        if (string.IsNullOrWhiteSpace(discriminator))
        {
            throw new ArgumentNullException(nameof(discriminator));
        }
        DateTime now = DateTime.Now;
        Id = Guid.NewGuid();
        DiscordId = discordId;
        DisplayName = displayName;
        Discriminator = discriminator;
        AvatarId = avatarId;
        Score = 0;
        CreatedAt = now;
        UpdatedAt = now;
        Status = PlayerStatus.Enable;
    }
}