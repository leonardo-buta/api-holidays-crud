using Holidays.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Holidays.Services.Interfaces
{
    public interface IHolidayAppService
    {
        Task InputHolidays();
        Task<HolidayDTO> CreateHoliday(HolidayDTO holidayDTO);
        Task<HolidayDTO> GetHoliday(int id);
        Task<List<HolidayDTO>> GetAllHolidays();
        Task<bool> ExistsHoliday(int id);
        Task UpdateHoliday(int id, HolidayUpdateDTO holidayDTO);
        Task DeleteHoliday(int id);
    }
}
