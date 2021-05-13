using Holidays.Domain.Models;
using System.Threading.Tasks;

namespace Holidays.Domain.Interfaces
{
    public interface IHolidayRepository : IRepository<Holiday>
    {
        Task<bool> ExistsHolidayByDate(string date);
        Task<Holiday> GetHolidayByTitle(string title);
    }
}
