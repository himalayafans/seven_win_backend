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
    public string DiscordId { get; set; } = string.Empty;

    /// <summary>
    /// Discord 名称
    /// </summary>
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>
    /// Discord标识符（4位数字,有前导0，因此不能用int）
    /// </summary>
    public string Discriminator { get; set; } = string.Empty;

    /// <summary>
    /// 头像ID
    /// </summary>
    public string AvatarId { get; set; } = string.Empty;

    /// <summary>
    /// 积分总数（即玉米数）
    /// </summary>
    public int Score { get; set; } = 0;

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
    public PlayerStatus Status { get; set; } = PlayerStatus.Enable;

    /// <summary>
    /// 创建玩家
    /// </summary>
    /// <param name="discordId">discord ID</param>
    /// <param name="displayName">Discord 名称</param>
    /// <param name="discriminator">Discord标识符（4位数字）</param>
    /// <param name="avatarId">Discord头像ID</param>
    public static Player Create(string discordId, string displayName, string discriminator, string avatarId)
    {
        if (string.IsNullOrWhiteSpace(discordId))
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
        return new Player()
        {
            Id = Guid.NewGuid(),
            DisplayName = displayName,
            Discriminator = discriminator,
            AvatarId = avatarId,
            DiscordId = discordId,
            Score = 0,
            CreatedAt = now,
            UpdatedAt = now,
            Status = PlayerStatus.Enable
        };
    }
    /// <summary>
    /// 设置积分
    /// </summary>
    public void SetScore(int score)
    {
        this.Score = score;
        this.UpdatedAt = DateTime.Now;
    }
}