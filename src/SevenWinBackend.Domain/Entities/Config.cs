using SevenWinBackend.Domain.Base;
using SevenWinBackend.Domain.Common;

namespace SevenWinBackend.Domain.Entities;

/// <summary>
/// 系统内部配置
/// </summary>
public class Config : BaseEntity
{
    /// <summary>
    /// 键名（必须唯一）
    /// </summary>
    public string KeyName { get; set; } = string.Empty;
    /// <summary>
    /// 键值（可以是JSON）
    /// </summary>
    public string KeyValue { get; set; } = string.Empty;

    /// <summary>
    /// 创建系统配置
    /// </summary>
    /// <param name="keyName">键</param>
    /// <param name="keyValue">值</param>

    public static Config Create(ConfigKeyName keyName, string keyValue)
    {
        return new Config()
        {
            Id = Guid.NewGuid(),
            KeyName = keyName.ToString(),
            KeyValue = keyValue
        };
    }
}