using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.DatabaseEFCore.Context
{
    public class DesignTimeBookingContextFactory : IDesignTimeDbContextFactory<BookingDBContext>
    {
        public BookingDBContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<BookingDBContext> optionsBuilder = new DbContextOptionsBuilder<BookingDBContext>();

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Booking;Persist Security Info=True; Integrated Security=True;",
                opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));

            return new BookingDBContext(optionsBuilder.Options);
        }
    }
}
