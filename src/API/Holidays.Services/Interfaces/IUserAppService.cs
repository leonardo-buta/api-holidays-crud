using Holidays.Services.DTO;
using System.Threading.Tasks;

namespace Holidays.Services.Interfaces
{
    public interface IUserAppService
    {
        Task<UserDTO> GetAsync(string username, string password);
    }
}
