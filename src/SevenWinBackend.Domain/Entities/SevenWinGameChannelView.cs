using SevenWinBackend.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Entities
{
    /// <summary>
    /// 出7制胜频道配置视图
    /// </summary>
    public class SevenWinGameChannelView : BaseView
    {
        public Guid ChannelId { get; set; }

        /// <summary>
        /// 是否是基础频道
        /// </summary>
        public bool IsBase { get; set; } = false;
        /// <summary>
        /// Discord ID
        /// </summary>
        public ulong DiscordId { get; set; } = 0;

        /// <summary>
        /// discord名称
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
