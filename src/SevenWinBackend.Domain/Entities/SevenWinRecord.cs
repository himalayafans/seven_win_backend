using SevenWinBackend.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Entities
{
    /// <summary>
    /// 出7制胜游戏记录
    /// </summary>
    public class SevenWinRecord : BaseEntity
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
        public Guid ImageId { get; set; }
        /// <summary>
        /// 是否是基础游戏
        /// </summary>
        public bool IsBase { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 创建出7制胜游戏记录
        /// </summary>
        public static SevenWinRecord Create(Guid playerGameId, Guid channelId, Guid imageId, bool isBase)
        {
            if (playerGameId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(playerGameId));
            }
            if (channelId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(channelId));
            }
            if (imageId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(imageId));
            }
            DateTime now = DateTime.Now;
            return new SevenWinRecord()
            {
                Id = Guid.NewGuid(),
                PlayerGameId = playerGameId,
                ChannelId = channelId,
                ImageId = imageId,
                CreatedAt = now,
                IsBase = isBase
            };
        }
    }
}
