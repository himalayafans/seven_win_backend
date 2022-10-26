using SevenWinBackend.Application.Games.SevenWin;
using SevenWinBackend.Application.Games.SevenWin.Base;
using SevenWinBackend.Common;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies.Standard
{
    /// <summary>
    /// LOGO检查策略
    /// </summary>
    internal class LogoStrategyHandler : BaseStrategyHandler
    {
        public override void Handle(StandardStrategyContext context)
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
    }
}
