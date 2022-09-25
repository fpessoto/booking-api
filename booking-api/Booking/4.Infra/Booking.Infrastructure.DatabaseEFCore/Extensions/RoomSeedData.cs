using Microsoft.EntityFrameworkCore;
using Booking.Domain.Users;
using Booking.Domain.Rooms;

namespace Booking.Infrastructure.DatabaseEFCore.Extensions
{
    public static class RoomSeedData
    {
        public static void SeedRooms(this ModelBuilder builder)
        {
            var user = new Room
            {
                Id = Guid.Parse("c83a4a7cccfd4625ae2398cf9f62ba2a"),
                Description = "The best room in the world! Beautiful view!",
                CreatedDate = new DateTime(2022, 3, 30, 16, 14, 37, 755, DateTimeKind.Utc).AddTicks(4636),
                UpdatedDate = new DateTime(2022, 3, 30, 16, 14, 37, 758, DateTimeKind.Utc).AddTicks(1509)
            };
            builder.Entity<Room>().HasData(user);
        }
    }
}