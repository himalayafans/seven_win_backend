using SevenWinBackend.Application.Games.SevenWin.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Games.SevenWin.Strategies
{
    /// <summary>
    /// 检查Discord发帖时间是否包含7策略
    /// </summary>
    internal class CheckDiscordTimeStrategy : BaseStrategy
    {
        public override async Task Handle(StrategyContext context)
        {
            // Discord发帖的分钟数
            var minute = context.SocketUserMessage.CreatedAt.Minute;
            // 获取分钟数的最后一位，例如 57 得到 7
            var lastNum = minute.ToString().ToCharArray().Last();
            // 末尾字符必须是7
            if (lastNum == '7')
            {
                await (this.Successor?.Handle(context) ?? Task.CompletedTask);
            }
            else
            {
                context.PlayResult.AddMessage("发帖时间的尾数不是7");
            }
        }
    }
}
