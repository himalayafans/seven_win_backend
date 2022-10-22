using SevenWinBackend.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Domain.Interfaces
{
    /// <summary>
    /// 仓储库接口
    /// </summary>
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(Guid id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(Guid id);
        Task<IEnumerable<T>> GetAll();
    }
}