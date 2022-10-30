using SevenWinBackend.Domain.Base;
using SevenWinBackend.Domain.Enums;

namespace SevenWinBackend.Domain.Entities;

/// <summary>
/// Discord频道
/// </summary>
public class Channel : BaseEntity
{
    /// <summary>
    /// 所属服务器ID
    /// </summary>
    public Guid GuildId { get; set; }

    /// <summary>
    /// Discord ID
    /// </summary>
    public ulong DiscordId { get; set; } = 0;

    /// <summary>
    /// discord名称
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Discord频道(禁止代码中调用)
    /// </summary>
    public Channel()
    {
    }

    /// <summary>
    /// Discord频道
    /// </summary>
    /// <param name="guildId">所属服务器ID</param>
    /// <param name="discordId">Discord ID</param>
    /// <param name="name">Discord名称</param>
    public Channel(Guid guildId, ulong discordId, string name)
    {
        Id = Guid.NewGuid();
        GuildId = guildId;
        DiscordId = discordId;
        Name = name;
    }
}