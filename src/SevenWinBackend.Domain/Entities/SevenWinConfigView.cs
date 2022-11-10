using SevenWinBackend.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Entities
{
    /// <summary>
    /// 出7制胜配置视图
    /// </summary>
    public class SevenWinConfigView : BaseView
    {
        /// <summary>
        /// 参与游戏的Discord频道
        /// </summary>
        public Guid ChannelId { get; set; }
        /// <summary>
        /// 是否是基础频道
        /// </summary>
        public bool IsBase { get; set; }
        /// <summary>
        /// Discord ID
        /// </summary>
        public string ChanneDiscordId { get; set; } = string.Empty;
        /// <summary>
        /// discord名称
        /// </summary>
        public string ChanneName { get; set; } = string.Empty;
        /// <summary>
        /// 服务器ID
        /// </summary>
        public Guid GuildId { get; set; }
        /// <summary>
        /// 服务器Discord ID
        /// </summary>
        public string GuildDiscordId { get; set; } = string.Empty;
        /// <summary>
        /// 服务器名称
        /// </summary>
        public string GuildName { get; set; } = string.Empty;
    }
}
