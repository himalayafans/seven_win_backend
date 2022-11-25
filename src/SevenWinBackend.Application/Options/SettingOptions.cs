using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Options
{
    /// <summary>
    /// 应用设置
    /// </summary>
    public class SettingOptions
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
        /// OcrSpace Key
        /// </summary>
        public List<string> OcrSpaceKeys { get; } = new List<string>();
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; }
        /// <summary>
        /// 出7制胜Discord频道配置
        /// </summary>
        public List<SevenWinGuildOption> SevenWinGuildOptions { get; set; } = new List<SevenWinGuildOption>();

        public SettingOptions(IConfiguration config)
        {
            DiscordToken = config.GetValue<string>("Discord:Token");
            EnableDiscordProxy = config.GetValue<bool>("Discord:Proxy");
            OcrSpaceKeys = config.GetSection("OcrSpaceKeys").Get<string[]>().ToList();
            ConnectionString = config.GetValue<string>("ConnectionStrings:Default");
            SevenWinGuildOptions = config.GetSection("SevenWinGuilds").Get<List<SevenWinGuildOption>>();
        }
        /// <summary>
        /// 验证配置选项
        /// </summary>
        public void Verify()
        {
            if (string.IsNullOrWhiteSpace(DiscordToken))
            {
                throw new ArgumentNullException(nameof(DiscordToken), "DiscordToken cannot be empty.");
            }
            if (OcrSpaceKeys.Count<=0 || OcrSpaceKeys.Exists(p=>string.IsNullOrWhiteSpace(p)))
            {
                throw new ArgumentNullException(nameof(OcrSpaceKeys), "OcrSpaceKeys is empty, or the element contains a null value");
            }
            if (string.IsNullOrWhiteSpace(ConnectionString))
            {
                throw new ArgumentNullException(nameof(ConnectionString), "ConnectionString cannot be empty.");
            }
            if (this.SevenWinGuildOptions == null || this.SevenWinGuildOptions.Count==0)
            {
                throw new ArgumentNullException(nameof(SevenWinGuildOptions), "SevenWinGuildOptions cannot be empty.");
            }
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
            Random random = new Random();
            int index = random.Next(0, OcrSpaceKeys.Count);
            return OcrSpaceKeys[index];
        }
    }
}
