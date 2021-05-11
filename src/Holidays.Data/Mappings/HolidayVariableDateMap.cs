using Holidays.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holidays.Data.Mappings
{
    public class HolidayVariableDateMap : IEntityTypeConfiguration<HolidayVariableDate>
    {
        public void Configure(EntityTypeBuilder<HolidayVariableDate> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Year)
                .HasColumnType("char(4)")
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(c => c.Date)
                .HasColumnType("char(5)")
                .HasMaxLength(5)
                .IsRequired();
        }
    }
}
