using SevenWinBackend.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Entities
{
    /// <summary>
    /// 出7制胜表
    /// </summary>
    public class SevenWinGame: BaseEntity
    {
        /// <summary>
        /// 玩家参与的游戏ID
        /// </summary>
        public Guid PlayerGameId { get;set; }
        /// <summary>
        /// Discord图片ID
        /// </summary>
        public Guid DiscordImageId { get;set; }
        /// <summary>
        /// 时间包含7的玉米数
        /// </summary>
        public double TimeScore { get;set; } 
        /// <summary>
        /// 价格中出现7的次数
        /// </summary>
        public int PriceTimes { get;set; }
        /// <summary>
        /// 价格出现7获得的玉米数
        /// </summary>
        public double PriceScore { get;set; }
    }
}
