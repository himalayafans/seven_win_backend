using SevenWinBackend.Application.Common;
using SevenWinBackend.Application.Data;

namespace SevenWinBackend.Application.Games.SevenWin.Core;

/// <summary>
/// 策略处理抽象类
/// </summary>
internal abstract class BaseStrategy
{
    /// <summary>
    /// 后继者
    /// </summary>
    protected BaseStrategy? Successor;

    public void SetSuccessor(BaseStrategy successor)
    {
        Successor = successor;
    }
    /// <summary>
    /// 处理请求
    /// </summary>
    public abstract Task Handle(StrategyContext context);
}