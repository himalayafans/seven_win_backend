namespace SevenWinBackend.Domain.Base;

/// <summary>
/// 实体基类
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// 主键ID
    /// </summary>
    public Guid Id { get; set; }
}