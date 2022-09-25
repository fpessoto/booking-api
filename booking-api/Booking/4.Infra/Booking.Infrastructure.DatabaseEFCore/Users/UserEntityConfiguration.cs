using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Booking.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.DatabaseEFCore.Users
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("TB_USER");

            builder.HasKey(x => x.Id);
            builder.Property(item => item.Email);
            builder.Property(item => item.Password);
            builder.Property(item => item.Role);
            builder.Property(item => item.CreatedDate).HasColumnType("timestamp without time zone");
            builder.Property(item => item.UpdatedDate).HasColumnType("timestamp without time zone");
            builder.Property(item => item.Username);
        }
    }
}
