namespace SevenWinBackend.Domain.Base;

/// <summary>
/// 视图基类
/// </summary>
public abstract class BaseView
{
    /// <summary>
    /// 主键ID
    /// </summary>
    public Guid Id { get; set; }
}