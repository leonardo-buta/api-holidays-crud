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
            CreateMap<Holiday, HolidayInputDTO>()
                .ForMember(dest => dest.VariableDates, opt => opt.MapFrom(src => src.HolidayVariableDates))
                .ReverseMap();

            CreateMap<Holiday, HolidayDTO>()
                .ForMember(dest => dest.VariableDates, opt => opt.MapFrom(src => src.HolidayVariableDates))
                .ReverseMap();

            CreateMap<HolidayVariableDate, HolidayVariableDateDTO>()
                .ReverseMap();

            CreateMap<Holiday, HolidayUpdateDTO>()
                .ForMember(dest => dest.VariableDates, opt => opt.MapFrom(src => src.HolidayVariableDates))
                .ReverseMap();

            CreateMap<HolidayVariableDate, KeyValuePair<string, string>>()
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Date))
                .ConstructUsing((t, ctx) => new KeyValuePair<string, string>(t.Year, t.Date))
                .ReverseMap();

            CreateMap<User, UserDTO>()
                .ReverseMap();
        }
    }
}
