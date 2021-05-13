using Holidays.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holidays.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Login)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.Password)
                .HasColumnType("varchar(72)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.Active)
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}
