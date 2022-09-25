using Microsoft.EntityFrameworkCore;

using Booking.Domain.Users;
using Booking.Infrastructure.DatabaseEFCore.Extensions;

using Booking.Domain.Reservations;
using Booking.Infrastructure.DatabaseEFCore.Reservations;
using Booking.Infrastructure.DatabaseEFCore.Users;
using Booking.Domain.Rooms;
using Booking.Infrastructure.DatabaseEFCore.Rooms;

namespace Booking.Infrastructure.DatabaseEFCore.Context
{
    public class BookingDBContext : DbContext
    {
        static BookingDBContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        //public DbSet<Room> Rooms { get; set; }
        //public DbSet<Team> Teams { get; set; }
        //public DbSet<Player> Players { get; set; }
        //public DbSet<Transfer> Transfers { get; set; }

        public BookingDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReservationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RoomEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new PlayerEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new TeamEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new TransferEntityConfiguration());

            modelBuilder.SeedUser();
            modelBuilder.SeedRooms();
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseNpgsql(@"User ID=sa;Password=123456;Host=localhost;Port=55000;Database=Booking;Pooling=true;");

            optionsBuilder.UseChangeTrackingProxies(false);
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.UseLazyLoadingProxies(false);
            optionsBuilder.EnableSensitiveDataLogging();
        }

    }
}
