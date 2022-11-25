using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Options
{
    /// <summary>
    /// 出7制胜服务器设置选项
    /// </summary>
    public class SevenWinGuildOption
    {
        /// <summary>
        /// Discord ID
        /// </summary>
        public string DiscordId { get; set; } = string.Empty;
        /// <summary>
        /// 频道配置
        /// </summary>
        public List<SevenWinChannelOption> Channels { get; set; } = new List<SevenWinChannelOption>();
        /// <summary>
        /// 是否是基础游戏频道
        /// </summary>
        public bool IsBaseChannel(string channelDiscordId)
        {
            return this.Channels.Exists(p => p.DiscordId == channelDiscordId && p.IsBase);
        }
        /// <summary>
        /// 是否属于附加游戏频道
        /// </summary>
        public bool IsAdditionChannel(string channelDiscordId)
        {
            return this.Channels.Exists(p => p.DiscordId == channelDiscordId && p.IsBase == false);
        }
        /// <summary>
        /// 获取随机空房间Discord ID
        /// </summary>
        public string GetRandomEmptyRoomDiscordId()
        {
            List<SevenWinChannelOption> options = Channels.Where(p => !p.IsBase).ToList();
            Random random= new Random();
            int num = random.Next(0, options.Count);
            return options[num].DiscordId;
        }
    }
}
