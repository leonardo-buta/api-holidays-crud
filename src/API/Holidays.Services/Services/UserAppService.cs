using AutoMapper;
using Holidays.Domain.Interfaces;
using Holidays.Services.DTO;
using Holidays.Services.Interfaces;
using System.Threading.Tasks;

namespace Holidays.Services.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserAppService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> GetAsync(string login, string password)
        {
            var user = await _userRepository.GetUser(login);
            var passwordMatch = DoesPasswordMatch(password, user.Password);

            if (!passwordMatch) return null;

            return _mapper.Map<UserDTO>(user);
        }

        private bool DoesPasswordMatch(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
