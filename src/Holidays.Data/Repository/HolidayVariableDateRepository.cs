using Holidays.Data.Context;
using Holidays.Domain.Interfaces;
using Holidays.Domain.Models;

namespace Holidays.Data.Repository
{
    public class HolidayVariableDateRepository : Repository<HolidayVariableDate>, IHolidayVariableDateRepository
    {
        public HolidayVariableDateRepository(HolidaysContext context)
            : base(context)
        {

        }
    }
}
