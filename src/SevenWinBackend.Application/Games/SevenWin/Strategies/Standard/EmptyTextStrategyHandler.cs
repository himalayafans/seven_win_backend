using SevenWinBackend.Application.Common;
using SevenWinBackend.Application.Data;
using SevenWinBackend.Application.Games.SevenWin.Base;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies.Standard
{
    /// <summary>
    /// 空文本检查策略
    /// </summary>
    class EmptyTextStrategyHandler : BaseStrategyHandler
    {
        public override void Handle(StandardStrategyContext context)
        {
            string text = context.OcrResult.GetText();
            if (string.IsNullOrWhiteSpace(text))
            {
                context.PlayResult.AddMessage("该截图没有包含任何文字");
            }
            else
            {
                Successor?.Handle(context);
            }
        }
    }
}
