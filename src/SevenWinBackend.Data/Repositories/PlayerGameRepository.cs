using PetaPoco;
using SevenWinBackend.Application.Repositories;
using SevenWinBackend.Data.Base;
using SevenWinBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Data.Repositories
{
    internal class PlayerGameRepository : BaseRepository<PlayerGame>, IPlayerGameRepository
    {
        public PlayerGameRepository(IDatabase db) : base(db)
        {
        }
    }
}
