using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Common
{
    /// <summary>
    /// 出7制胜游戏频道配置
    /// </summary>
    public sealed class SevenGameConfig
    {
        /// <summary>
        /// 常规频道ID
        /// </summary>
        public Guid CommonChannelId { get; set; }
        /// <summary>
        /// 高级频道ID列表
        /// </summary>
        public List<Guid> AdvancedChannelIds { get; set; } = new List<Guid>(); // 除了常规频道，另外7个频道的ID
    }
}