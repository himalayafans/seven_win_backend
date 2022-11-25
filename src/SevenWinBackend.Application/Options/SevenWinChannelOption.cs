using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Options
{
    /// <summary>
    /// 出7制胜频道设置选项
    /// </summary>
    public class SevenWinChannelOption
    {
        /// <summary>
        /// Discord ID
        /// </summary>
        public string DiscordId { get; set; } = string.Empty;
        /// <summary>
        /// 是否是基础游戏频道
        /// </summary>
        public bool IsBase { get; set; } = false;
    }
}
