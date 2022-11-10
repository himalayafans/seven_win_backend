using SevenWinBackend.Common;
using SevenWinBackend.Domain.Base;
using SevenWinBackend.Domain.Common;
using SevenWinBackend.Domain.Enums;

namespace SevenWinBackend.Domain.Entities;

/// <summary>
/// 系统内部配置
/// </summary>
public class Config : BaseEntity
{
    /// <summary>
    /// 键名（必须唯一）
    /// </summary>
    public ConfigKeyNames KeyName { get; set; } = ConfigKeyNames.None;
    /// <summary>
    /// 键值（可以是JSON）
    /// </summary>
    public string KeyValue { get; set; } = string.Empty;

    /// <summary>
    /// 创建系统配置
    /// </summary>
    /// <param name="keyName">键</param>
    /// <param name="keyValue">值</param>
    public static Config Create(ConfigKeyNames keyName, string keyValue)
    {
        return new Config()
        {
            Id = Guid.NewGuid(),
            KeyName = keyName,
            KeyValue = keyValue
        };
    }
}