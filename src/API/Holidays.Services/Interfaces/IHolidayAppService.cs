using Holidays.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Holidays.Services.Interfaces
{
    public interface IHolidayAppService
    {
        Task InputHolidays();
        Task<List<HolidayDTO>> GetAllHolidays();
    }
}
