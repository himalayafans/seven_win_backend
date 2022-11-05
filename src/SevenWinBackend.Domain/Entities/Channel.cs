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
    public string DiscordId { get; set; } = string.Empty;

    /// <summary>
    /// discord名称
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 创建Discord频道
    /// </summary>
    /// <param name="guildId">discord服务器ID</param>
    /// <param name="discordId">频道Discord id</param>
    /// <param name="name">频道名称</param>
    /// <returns></returns>
    public static Channel Create(Guid guildId, string discordId, string name)
    {
        return new Channel() { Id = Guid.NewGuid(), DiscordId = discordId, GuildId = guildId, Name = name };
    }
}