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
    public ulong DiscordId { get; set; }

    /// <summary>
    /// Discord名称
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Discord服务器(禁止代码中调用)
    /// </summary>
    public Guild()
    {
    }
    /// <summary>
    /// Discord服务器
    /// </summary>
    /// <param name="discordId">discord ID</param>
    /// <param name="name">Discord名称</param>
    public Guild(ulong discordId, string name)
    {
        DiscordId = discordId;
        Name = name;
    }
}