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
    public string KeyName { get; set; }
    /// <summary>
    /// 键值（可以是JSON）
    /// </summary>
    public string KeyValue { get; set; }
    /// <summary>
    /// 应用配置(禁止代码中调用)
    /// </summary>
    public Config()
    {
        this.KeyName = String.Empty;
        this.KeyValue = String.Empty;
    }
    /// <summary>
    /// 应用配置
    /// </summary>
    public Config(ConfigKeyName keyName, string keyValue)
    {
        KeyName = keyName.ToString();
        KeyValue = keyValue;
    }
}