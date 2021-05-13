using System;
using System.Linq;
using System.Threading.Tasks;

namespace Holidays.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity obj);
        Task<TEntity> GetByIdAsync(int id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        Task RemoveAsync(int id);
        Task<int> SaveChangesAsync();
    }
}
