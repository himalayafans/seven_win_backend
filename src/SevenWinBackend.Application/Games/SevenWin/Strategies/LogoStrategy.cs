using SevenWinBackend.Application.Games.SevenWin.Core;
using SevenWinBackend.Common;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies
{
    /// <summary>
    /// LOGO检查策略
    /// </summary>
    internal class LogoStrategy : BaseStrategy
    {
        public override Task Handle(StrategyContext context)
        {
            if (context.OcrResult != null)
            {
                string text = context.OcrResult.GetText();
                // 偶尔会被识别为 HIMALA AYA  EEXCHANGE
                if (text.ContainsIgnoreCase("himala") && text.ContainsIgnoreCase("exchange"))
                {
                    Successor?.Handle(context);
                }
                else
                {
                    context.PlayResult.AddMessage("截图没有喜交所的LOGO或网址");
                }
            }
            return Task.CompletedTask;
        }
    }
}
