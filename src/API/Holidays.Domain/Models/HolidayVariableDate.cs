namespace Holidays.Domain.Models
{
    public class HolidayVariableDate : Entity
    {
        public Holiday Holiday { get; set; }

        public string Year { get; set; }

        public string Date { get; set; }
    }
}
