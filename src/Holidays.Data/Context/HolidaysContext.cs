using Holidays.Data.Mappings;
using Holidays.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Holidays.Data.Context
{
    public class HolidaysContext : DbContext
    {
        public HolidaysContext(DbContextOptions<HolidaysContext> options) : base(options) { }

        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<HolidayVariableDate> HolidayVariableDates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HolidayMap());
            modelBuilder.ApplyConfiguration(new HolidayVariableDateMap()); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
