using SevenWinBackend.Domain.Base;
using SevenWinBackend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Entities
{
    /// <summary>
    /// 出7制胜频道配置表
    /// </summary>
    public class SevenWinGameChannel : BaseEntity
    {
        public Guid ChannelId { get; set; }

        /// <summary>
        /// 是否是基础频道
        /// </summary>
        public bool IsBase { get; set; } = false;

        public static SevenWinGameChannel Create(Guid channelId, bool isBase)
        {
            if (channelId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(channelId));
            }
            return new SevenWinGameChannel()
            {
                Id = Guid.NewGuid(),
                ChannelId = channelId,
                IsBase = isBase
            };
        }
    }
}
