using AutoMapper;
using Holidays.Domain.Interfaces;
using Holidays.Services.Interfaces;

namespace Holidays.Services.Services
{
    public class HolidayAppService : IHolidayAppService
    {
        private readonly IMapper _mapper;
        private readonly IHolidayRepository _holidayRepository;

        public HolidayAppService(IMapper mapper, IHolidayRepository holidayRepository)
        {
            _mapper = mapper;
            _holidayRepository = holidayRepository;
        }
    }
}
