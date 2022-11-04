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
    public class SevenWinGameRecord : BaseEntity
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
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// 是否完成（游戏执行过程有延迟，例如Ocr识别，需要先产生记录->Ocr->积分，才算完成）
        /// </summary>
        public bool IsFinish { get; set; } = false;

        public SevenWinGameRecord()
        {
        }

        public SevenWinGameRecord(Guid playerGameId, Guid channelId, Guid discordImageId)
        {
            Id = Guid.NewGuid();
            PlayerGameId = playerGameId;
            ChannelId = channelId;
            DiscordImageId = discordImageId;
            CreatedAt = DateTime.Now;
            this.IsFinish = false;
        }
    }
}
