using Booking.Infrastructure.DatabaseEFCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Infrastructure.DatabaseEFCore
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            var useOnlyInMemoryDatabase = false;
            if (configuration["UseOnlyInMemoryDatabase"] != null)
            {
                useOnlyInMemoryDatabase = bool.Parse(configuration["UseOnlyInMemoryDatabase"]);
            }

            if (useOnlyInMemoryDatabase)
            {
                services.AddDbContext<BookingDBContext>(c =>
                   c.UseInMemoryDatabase("Booking"));
            }
            else
            {
                // use real database
                // Requires LocalDB which can be installed with SQL Server Express 2016
                // https://www.microsoft.com/en-us/download/details.aspx?id=54284
                services.AddDbContext<BookingDBContext>(c =>
                    c.UseSqlServer(configuration.GetConnectionString("BookingConnection")));
            }
        }
    }
}
