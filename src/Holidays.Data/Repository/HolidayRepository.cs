using Holidays.Data.Context;
using Holidays.Domain.Interfaces;
using Holidays.Domain.Models;

namespace Holidays.Data.Repository
{
    public class HolidayRepository : Repository<Holiday>, IHolidayRepository
    {
        public HolidayRepository(HolidaysContext context)
            : base(context)
        {

        }
    }
}
