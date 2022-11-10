using PetaPoco;
using SevenWinBackend.Application.Data;
using SevenWinBackend.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        internal readonly PetaPoco.IDatabase db;

        internal UnitOfWork(PetaPoco.IDatabase db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IAccountRepository Account => throw new NotImplementedException();

        public IChannelRepository Channel => throw new NotImplementedException();

        public IConfigRepository Config => throw new NotImplementedException();

        public IDiscordImageRepository DiscordImage => throw new NotImplementedException();

        public IGuildRepository Guild => throw new NotImplementedException();

        public IPlayerGameRepository PlayerGame => throw new NotImplementedException();

        public IPlayerGameViewRepository PlayerGameView => throw new NotImplementedException();

        public IPlayerRepository Player => throw new NotImplementedException();

        public ISevenWinConfigRepository SevenWinGameChannel => throw new NotImplementedException();

        public ISevenWinConfigViewRepository SevenWinConfigView => throw new NotImplementedException();

        public ISevenWinRecordViewRepository SevenWinGameRecordView => throw new NotImplementedException();

        public ISevenWinRecordRepository SevenWinGameRecord => throw new NotImplementedException();

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }
        public async Task ExecuteAsync(string sql, params object[] args)
        {
            await this.db.ExecuteAsync(sql, args);
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.db.Dispose();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql, params object[] args)
        {
            return await this.db.ExecuteScalarAsync<T>(sql, args);
        }
    }
}
