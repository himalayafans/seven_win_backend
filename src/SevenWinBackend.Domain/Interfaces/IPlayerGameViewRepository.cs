using SevenWinBackend.Domain.Common;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Interfaces
{
    public interface IPlayerGameViewRepository
    {
        Task<PlayerGameView> GetPlayerGameViewAsync();
        Task<PageResult<PlayerGameView>> Search(IQueryOptions options);
    }
}
