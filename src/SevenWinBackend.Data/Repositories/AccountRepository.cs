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
    public class AccountRepository : BaseRepository<Account>
    {
        public AccountRepository(IDatabase db) : base(db)
        {
        }

    }
}
