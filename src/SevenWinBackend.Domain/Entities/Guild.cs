using SevenWinBackend.Domain.Base;

namespace SevenWinBackend.Domain.Entities;

/// <summary>
/// Discord服务器
/// </summary>
public class Guild : BaseEntity
{
    /// <summary>
    /// discord ID
    /// </summary>
    public string DiscordId { get; set; } = string.Empty;

    /// <summary>
    /// Discord名称
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 创建Discord服务器
    /// </summary>
    public static Guild Create(string discordId, string name)
    {
        if (discordId == string.Empty)
        {
            throw new ArgumentNullException(nameof(discordId));
        }
        if (name == string.Empty)
        {
            throw new ArgumentNullException(nameof(name));
        }
        return new Guild()
        {
            Id = Guid.NewGuid(),
            Name = name,
            DiscordId = discordId
        };
    }
}