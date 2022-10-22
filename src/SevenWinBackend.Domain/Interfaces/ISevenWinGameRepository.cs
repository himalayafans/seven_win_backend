using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Interfaces
{
    /// <summary>
    /// 出7制胜存储库
    /// </summary>
    public interface ISevenWinGameRepository: IRepository<SevenWinGame>
    {
        Task<List<SevenWinGame>> GetPlayerGameId(Guid playerGameId);
    }
}
