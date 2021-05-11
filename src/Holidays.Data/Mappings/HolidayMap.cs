using Holidays.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holidays.Data.Mappings
{
    public class HolidayMap : IEntityTypeConfiguration<Holiday>
    {
        public void Configure(EntityTypeBuilder<Holiday> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Date)
                .HasColumnType("char(5)")
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(c => c.Title)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.Legislation)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.Type)
                .HasColumnType("tinyint")
                .IsRequired();

            builder.Property(c => c.StartTime)
                .HasColumnType("varchar(5)")
                .HasMaxLength(5);

            builder.Property(c => c.EndTime)
                .HasColumnType("varchar(5)")
                .HasMaxLength(5);
        }
    }
}
