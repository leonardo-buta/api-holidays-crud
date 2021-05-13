﻿using AutoMapper;
using Holidays.Domain.Interfaces;
using Holidays.Domain.Models;
using Holidays.Services.DTO;
using Holidays.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Holidays.Services.Services
{
    public class HolidayAppService : IHolidayAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHolidayRepository _holidayRepository;
        private readonly IHolidayVariableDateRepository _holidayVariableDateRepository;

        public HolidayAppService(IMapper mapper, IUnitOfWork unitOfWork, IHolidayRepository holidayRepository, IHolidayVariableDateRepository holidayVariableDateRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _holidayRepository = holidayRepository;
            _holidayVariableDateRepository = holidayVariableDateRepository;
        }

        public async Task LoadHolidays()
        {
            string json = string.Empty;

            using (var httpClient = new HttpClient())
            {
                json = await httpClient.GetStringAsync("https://dadosbr.github.io/feriados/nacionais.json");
            }

            if (!string.IsNullOrEmpty(json))
            {
                var holidays = JsonConvert.DeserializeObject<List<HolidayDTO>>(json);

                foreach (var holiday in holidays)
                {
                    if (!string.IsNullOrEmpty(holiday.Date))
                    {
                        var exists = await _holidayRepository.ExistsHolidayByDate(holiday.Date);

                        if (!exists)
                        {
                            await _holidayRepository.AddAsync(_mapper.Map<Holiday>(holiday));
                        }
                    }
                    else if (holiday.HolidayVariableDates.Count > 0)
                    {
                        var existingHoliday = await _holidayRepository.GetHolidayByTitle(holiday.Title);

                        if (existingHoliday == null)
                        {
                            await _holidayRepository.AddAsync(_mapper.Map<Holiday>(holiday));
                        }
                        else
                        {
                            foreach (var variableDate in holiday.HolidayVariableDates)
                            {
                                var exists = existingHoliday.HolidayVariableDates.Any(x => x.Year == variableDate.Key &&
                                                                                           x.Date == variableDate.Value);

                                if (!exists)
                                {
                                    var holidayVariableDate = _mapper.Map<HolidayVariableDate>(variableDate);
                                    holidayVariableDate.Holiday = existingHoliday;
                                    await _holidayVariableDateRepository.AddAsync(holidayVariableDate);
                                }
                            }
                        }
                    }
                }

                await _unitOfWork.CommitAsync();
            }
        }
    }
}
