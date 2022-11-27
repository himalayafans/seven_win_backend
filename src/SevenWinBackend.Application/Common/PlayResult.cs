using SevenWinBackend.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Common
{
    /// <summary>
    /// 游戏结果
    /// </summary>
    public class PlayResult
    {
        /// <summary>
        /// 提示信息
        /// </summary>
        private StringBuilder Tips { get; } = new StringBuilder();
        /// <summary>
        /// 积分总数
        /// </summary>
        public int TotalScore { get; set; } = 0;

        /// <summary>
        /// 增加Discord回复消息
        /// </summary>
        public void AddMessage(string msg)
        {
            this.Tips.AppendLine(msg);
        }

        public override string ToString()
        {
            var tip = Tips.ToString();
            if (string.IsNullOrWhiteSpace(tip))
            {
                return string.Empty;
            }
            var sb = new StringBuilder();
            sb.AppendLine($"本次获得玉米总数:{TotalScore}");
            sb.Append(Tips);
            sb.AppendLine("您的玉米总数请咨询“出7致胜”管理员");
            sb.AppendLine("感谢您关注喜马拉雅交易所，用喜元、玩喜币、跟着喜支付一起飞……");
            return sb.ToString();
        }
    }
}
