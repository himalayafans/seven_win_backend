using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Games.SevenWin.Core
{
    /// <summary>
    /// 数据缓存
    /// </summary>
    internal class DataCache
    {
        /// <summary>
        /// 当前消息的频道ID
        /// </summary>
        public Guid ChannelId { get; set; } = Guid.Empty;
        /// <summary>
        /// 玩家ID
        /// </summary>
        public Guid PlayerId { get; set; } = Guid.Empty;
        /// <summary>
        /// 图片ID
        /// </summary>
        public Guid ImageId { get; set; } = Guid.Empty;
        /// <summary>
        /// 游戏ID
        /// </summary>
        public Guid PlayerGameId { get; set; } = Guid.Empty;
        /// <summary>
        /// 游戏记录ID
        /// </summary>
        public Guid GameRecordId { get; set; } = Guid.Empty;
        /// <summary>
        /// 游戏频道配置
        /// </summary>
        public List<SevenWinConfigView> Channels { get; set; } = new List<SevenWinConfigView>();
    }
}
