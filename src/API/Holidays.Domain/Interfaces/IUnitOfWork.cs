using System;
using System.Threading.Tasks;

namespace Holidays.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
    }
}
