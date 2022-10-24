using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Interfaces
{
    /// <summary>
    /// 应用程序设置
    /// </summary>
    public interface IAppSettings
    {
        /// <summary>
        /// Discord Token
        /// </summary>
        public string DiscordToken { get; }
        /// <summary>
        /// Discord网络通信是否启用代理
        /// </summary>
        public bool EnableDiscordProxy { get; }
        /// <summary>
        /// 是否启用机器人
        /// </summary>
        public bool BotEnabled { get; }
        /// <summary>
        /// OcrSpace Key
        /// </summary>
        public string OcrSpaceKey { get; }
    }
}
