using Holidays.Domain.Enums;
using System.Collections.Generic;

namespace Holidays.Domain.Models
{
    public class Holiday : Entity
    {
        public string Date { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Legislation { get; set; }

        public HolidayType Type { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public List<HolidayVariableDate> HolidayVariableDates { get; set; }
    }
}
