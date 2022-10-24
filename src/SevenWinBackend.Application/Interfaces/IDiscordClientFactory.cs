using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Interfaces
{
    /// <summary>
    /// Discord客户端工厂类
    /// </summary>
    public interface IDiscordClientFactory
    {
        DiscordSocketClient Create();
    }
}