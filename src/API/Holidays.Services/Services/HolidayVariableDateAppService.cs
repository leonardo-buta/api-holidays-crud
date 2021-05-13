using AutoMapper;
using Holidays.Domain.Interfaces;
using Holidays.Services.Interfaces;

namespace Holidays.Services.Services
{
    public class HolidayVariableDateAppService : IHolidayVariableDateAppService
    {
        private readonly IMapper _mapper;
        private readonly IHolidayVariableDateRepository _holidayVariableDateRepository;

        public HolidayVariableDateAppService(IMapper mapper, IHolidayVariableDateRepository holidayVariableDateRepository)
        {
            _mapper = mapper;
            _holidayVariableDateRepository = holidayVariableDateRepository;
        }
    }
}
