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
        public StringBuilder Tips { get; } = new StringBuilder();

        /// <summary>
        /// 获取的总分数
        /// </summary>
        public int TotalScore { get; set; }
    }
}
