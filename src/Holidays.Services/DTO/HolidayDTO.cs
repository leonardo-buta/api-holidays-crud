using Holidays.Domain.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Holidays.Services.DTO
{
    public class HolidayDTO
    {
        public string Date { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Legislation { get; set; }

        public HolidayType Type { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        [JsonProperty("variableDates")]
        public Dictionary<string, string> HolidayVariableDates { get; set; }
    }
}
