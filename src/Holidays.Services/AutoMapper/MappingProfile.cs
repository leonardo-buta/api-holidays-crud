using AutoMapper;
using Holidays.Domain.Models;
using Holidays.Services.DTO;
using System.Collections.Generic;

namespace Holidays.Services.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Holiday, HolidayDTO>().ReverseMap();
            CreateMap<KeyValuePair<string, string>, HolidayVariableDate>()
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Key))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Value));
        }
    }
}
