using Holidays.Domain.Models;
using System.Threading.Tasks;

namespace Holidays.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUser(string login);
    }
}
