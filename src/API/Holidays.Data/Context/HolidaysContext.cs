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
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mappings
            modelBuilder.ApplyConfiguration(new HolidayMap());
            modelBuilder.ApplyConfiguration(new HolidayVariableDateMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            // Seed
            modelBuilder.Entity<User>().HasData(new User { Id = 1, Login = "admin", Password = "$2a$11$.s5nyT0X8zhfGCUmG.IMvOcCEMNE3rPIEmxvnYIwf2WtMQ5h0oyHm", Active = true });

            base.OnModelCreating(modelBuilder);
        }
    }
}
