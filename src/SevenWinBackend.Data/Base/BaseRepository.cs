using SevenWinBackend.Application.Base;
using SevenWinBackend.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace SevenWinBackend.Data.Base
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected IDatabase Db { get; }

        public BaseRepository(IDatabase db)
        {
            Db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task Add(T entity)
        {
            await this.Db.InsertAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await this.Db.DeleteAsync<T>(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await this.Db.FetchAsync<T>();
        }

        public async Task<T> GetById(Guid id)
        {
            return await this.Db.SingleOrDefaultAsync<T>(id);
        }

        public async Task Update(T entity)
        {
            await this.Db.UpdateAsync(entity);
        }
    }
}
