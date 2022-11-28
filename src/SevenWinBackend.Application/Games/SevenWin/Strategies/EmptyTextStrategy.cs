using SevenWinBackend.Application.Games.SevenWin.Core;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies
{
    /// <summary>
    /// 空文本检查策略
    /// </summary>
    class EmptyTextStrategy : BaseStrategy
    {
        public override async Task Handle(StrategyContext context)
        {
            if (context.OcrResult == null)
            {
                throw new ArgumentNullException(nameof(context.OcrResult));
            }
            var text = context.OcrResult.GetText();
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new Exception("该截图没有包含任何文字");
            }
            await (this.Successor?.Handle(context) ?? Task.CompletedTask);
        }
    }
}
