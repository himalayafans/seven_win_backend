using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Interfaces
{
    /// <summary>
    /// 玩家游戏储存库
    /// </summary>
    public interface IPlayerGameRepository: IRepository<PlayerGame>
    {
    }
}
