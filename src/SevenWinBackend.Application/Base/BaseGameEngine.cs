using Discord.WebSocket;
using SevenWinBackend.Application.Common;
using SevenWinBackend.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Base
{
    /// <summary>
    /// 游戏引擎基类
    /// </summary>
    public abstract class BaseGameEngine
    {
        /// <summary>
        /// 下一个游戏
        /// </summary>
        protected BaseGameEngine? Successor { get; set; }
        public void SetSuccessor(BaseGameEngine game)
        {
            Successor = game;
        }
        public abstract Task Handle(SocketUserMessage message, PlayResult playResult);
    }
}