using Holidays.Data.Context;
using Holidays.Domain.Interfaces;
using Holidays.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Holidays.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(HolidaysContext context)
            : base(context)
        {

        }

        public Task<User> GetUser(string login)
        {
            return DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Login.ToLower() == login.ToLower());
        }
    }
}
