using Holidays.Data.Context;
using Holidays.Domain.Interfaces;
using System.Threading.Tasks;

namespace Holidays.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HolidaysContext _context;

        public UnitOfWork(HolidaysContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
