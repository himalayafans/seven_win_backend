using SevenWinBackend.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Entities
{
    /// <summary>
    /// 出7制胜配置
    /// </summary>
    public class SevenWinConfig : BaseEntity
    {
        /// <summary>
        /// 参与游戏的Discord频道
        /// </summary>
        public Guid ChannelId { get; set; }
        /// <summary>
        /// 是否是基础频道
        /// </summary>
        public bool IsBase { get; set; }
    }
}
