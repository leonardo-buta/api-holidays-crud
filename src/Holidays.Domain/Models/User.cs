namespace Holidays.Domain.Models
{
    public class User : Entity
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; }
    }
}
