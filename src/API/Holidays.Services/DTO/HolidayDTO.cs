using Holidays.Domain.Enums;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Holidays.Services.DTO
{
    public class HolidayDTO
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Legislation { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public HolidayType Type { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public Dictionary<string, string> VariableDates { get; set; }
    }
}
