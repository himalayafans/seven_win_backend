using SevenWinBackend.Application.Interfaces;
using SevenWinBackend.Application.Repositories;
using SevenWinBackend.Data.Base;
using SevenWinBackend.Domain.Common;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace SevenWinBackend.Data.Repositories
{
    internal class PlayerGameViewRepository : IPlayerGameViewRepository
    {
        private IDatabase Db { get; }

        public PlayerGameViewRepository(IDatabase db)
        {
            Db = db ?? throw new ArgumentNullException(nameof(db));
        }

        Task<PageResult<PlayerGameView>> IPlayerGameViewRepository.Search(IQueryOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
