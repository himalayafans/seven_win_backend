using SevenWinBackend.Application.Games.SevenWin.Core;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies
{
    /// <summary>
    /// 空文本检查策略
    /// </summary>
    class EmptyTextStrategy : BaseStrategy
    {
        public override Task Handle(StrategyContext context)
        {
            if (context.OcrResult != null)
            {
                var text = context.OcrResult.GetText();
                if (string.IsNullOrWhiteSpace(text))
                {
                    context.PlayResult.AddMessage("该截图没有包含任何文字");
                }
                else if (Successor != null)
                {
                    return Successor.Handle(context);
                }
            }
            return Task.CompletedTask;
        }
    }
}
