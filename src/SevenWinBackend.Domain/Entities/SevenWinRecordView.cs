using SevenWinBackend.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Entities
{
    /// <summary>
    /// 出7制胜游戏记录视图
    /// </summary>
    public class SevenWinRecordView : BaseView
    {
        /// <summary>
        /// 玩家参与的游戏ID
        /// </summary>
        public Guid PlayerGameId { get; set; }
        /// <summary>
        /// 参与游戏的Discord频道
        /// </summary>
        public Guid ChannelId { get; set; }
        /// <summary>
        /// Discord图片ID
        /// </summary>
        public Guid DiscordImageId { get; set; }
        /// <summary>
        /// 是否是基础游戏
        /// </summary>
        public bool IsBase { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// 玩家ID
        /// </summary>
        public Guid PlayerId { get; set; }
        /// <summary>
        /// 玩家discord ID
        /// </summary>
        public string PlayerDiscordId { get; set; } = string.Empty;
        /// <summary>
        /// 玩家Discord 名称
        /// </summary>
        public string PlayerDisplayName { get; set; } = String.Empty;
        /// <summary>
        /// 玩家Discord标识符（4位数字,有前导0，因此不能用int）
        /// </summary>
        public string PlayerDiscriminator { get; set; } = string.Empty;
        /// <summary>
        /// 玩家头像ID
        /// </summary>
        public string PlayerAvatarId { get; set; } = string.Empty;
        /// <summary>
        /// 频道Discord ID
        /// </summary>
        public string ChannelDiscordId { get; set; } = string.Empty;
        /// <summary>
        /// 频道discord名称
        /// </summary>
        public string ChannelName { get; set; } = string.Empty;
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
        public string GuildName { get; set;} = string.Empty;
    }
}
