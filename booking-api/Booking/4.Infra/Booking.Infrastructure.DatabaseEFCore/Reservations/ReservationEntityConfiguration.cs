using Booking.Domain.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.DatabaseEFCore.Reservations
{
    public class ReservationEntityConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("TB_RESERVATION");

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.IsActive);
            builder.Property(x => x.StartDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.EndDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.UserId);
            builder.Property(x => x.RoomId);
            builder.Property(x => x.CreatedDate).HasColumnType("timestamp without time zone");
            builder.Property(x => x.UpdatedDate).HasColumnType("timestamp without time zone");
        }
    }
}
