using Discord.WebSocket;
using SevenWinBackend.Application.Base;
using SevenWinBackend.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Games.SevenWin
{
    /// <summary>
    /// 出7制胜游戏引擎
    /// </summary>
    public class SevenWinGameEngine : BaseGameEngine
    {
        private static readonly List<string> _imageTypes = new List<string>()
        {
            "image/jpeg",
            //"image/gif",
            "image/png",
            //"image/bmp"
        };

        public override void Handle(SocketMessage message)
        {

        }
    }
}
