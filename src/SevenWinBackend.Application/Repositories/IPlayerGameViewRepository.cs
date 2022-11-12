using SevenWinBackend.Application.Interfaces;
using SevenWinBackend.Domain.Common;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Repositories
{
    public interface IPlayerGameViewRepository
    {
        Task<PageResult<PlayerGameView>> Search(IQueryOptions options);
    }
}
