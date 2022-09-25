using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Booking.Infrastructure.DatabaseEFCore.Context
{
    public class DesignTimeBookingContextFactory : IDesignTimeDbContextFactory<BookingDBContext>
    {
        public BookingDBContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<BookingDBContext> optionsBuilder = new DbContextOptionsBuilder<BookingDBContext>();

            optionsBuilder.UseNpgsql(@"User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=Booking;Pooling=true;");
                
            return new BookingDBContext(optionsBuilder.Options);
        }
    }
}
