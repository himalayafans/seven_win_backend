using PetaPoco;
using SevenWinBackend.Application.Data;
using SevenWinBackend.Application.Repositories;
using SevenWinBackend.Data.Repositories;
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
            this.Account = new AccountRepository(db);
            this.Channel = new ChannelRepository(db);
            this.Config = new ConfigRepository(db);
            this.Image = new ImageRepository(db);
            this.Guild = new GuildRepository(db);
            this.Player = new PlayerRepository(db);
            this.PlayerGame = new PlayerGameRepository(db);
            this.PlayerGameView = new PlayerGameViewRepository(db);
            this.SevenWinConfig = new SevenWinConfigRepository(db);
            this.SevenWinConfigView = new SevenWinConfigViewRepository(db);
            this.SevenWinRecord = new SevenWinRecordRepository(db);
            this.SevenWinRecordView = new SevenWinRecordViewRepository(db);
        }

        public IAccountRepository Account { get; }

        public IChannelRepository Channel { get; }

        public IConfigRepository Config { get; }

        public IImageRepository Image { get; }

        public IGuildRepository Guild { get; }

        public IPlayerGameRepository PlayerGame { get; }

        public IPlayerGameViewRepository PlayerGameView { get; }

        public IPlayerRepository Player { get; }

        public ISevenWinConfigRepository SevenWinConfig { get; }

        public ISevenWinConfigViewRepository SevenWinConfigView { get; }

        public ISevenWinRecordViewRepository SevenWinRecordView { get; }

        public ISevenWinRecordRepository SevenWinRecord { get; }

        public void BeginTransaction()
        {
            this.db.BeginTransaction();
        }
        public async Task ExecuteAsync(string sql, params object[] args)
        {
            await this.db.ExecuteAsync(sql, args);
        }

        public void Commit()
        {
            this.db.CompleteTransaction();
        }

        public void Dispose()
        {
            this.db.Dispose();
        }

        public void Rollback()
        {
            this.db.AbortTransaction();
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql, params object[] args)
        {
            return await this.db.ExecuteScalarAsync<T>(sql, args);
        }
    }
}
