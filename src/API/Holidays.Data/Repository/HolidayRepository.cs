using Holidays.Data.Context;
using Holidays.Domain.Interfaces;
using Holidays.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Holidays.Data.Repository
{
    public class HolidayRepository : Repository<Holiday>, IHolidayRepository
    {
        public HolidayRepository(HolidaysContext context)
            : base(context)
        {

        }

        public async Task<bool> ExistsHolidayByDate(string date)
        {
            return await DbSet.AnyAsync(x => x.Date == date);
        }

        public async Task<Holiday> GetHolidayByTitle(string title)
        {
            return await DbSet.Include(x => x.HolidayVariableDates)
                              .FirstOrDefaultAsync(x => x.Title.ToLower() == title.ToLower());
        }
    }
}
