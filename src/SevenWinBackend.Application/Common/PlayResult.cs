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
        /// 增加Discord回复消息
        /// </summary>
        public void AddMessage(string msg)
        {
            this.Tips.AppendLine(msg);
        }

        public override string ToString()
        {
            return Tips.ToString();
        }
    }
}
