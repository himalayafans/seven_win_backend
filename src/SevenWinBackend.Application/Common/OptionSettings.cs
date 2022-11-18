using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Common
{
    /// <summary>
    /// 应用设置
    /// </summary>
    public class OptionSettings
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
        public List<string> OcrSpaceKeys { get; } = new List<string>();
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; }

        public OptionSettings(IConfiguration config)
        {
            this.DiscordToken = config.GetValue<string>("Discord:Token");
            this.EnableDiscordProxy = config.GetValue<bool>("Discord:Proxy");
            this.OcrSpaceKeys = config.GetSection("OcrSpaceKeys").Get<string[]>().ToList();
            this.ConnectionString = config.GetValue<string>("ConnectionStrings:Default");
            BotEnabled = true;
        }
        /// <summary>
        /// 随机获取OcrSpaceKey
        /// </summary>
        /// <returns></returns>
        public string GetRandomOcrSpaceKey()
        {
            if (OcrSpaceKeys.Count == 0)
            {
                throw new InvalidOperationException("配置文件没有设置OcrSpaceKeys");
            }
            Random random= new Random();
            int index = random.Next(0, OcrSpaceKeys.Count);
            return OcrSpaceKeys[index];
        }
    }
}
