using Microsoft.EntityFrameworkCore;
using Booking.Domain.Users;

namespace Booking.Infrastructure.DatabaseEFCore.Extensions
{
    public static class UserSeedData
    {
        public static void SeedUser(this ModelBuilder builder)
        {
            var user1 = new User
            {
                Id = Guid.Parse("4db89c05-1b67-4771-96a2-4b607d287123"),
                Email = "admin@admin.com",
                Password = "admin",
                Role = "admin",
                Username = "admin",
                CreatedDate = new DateTime(2022, 3, 30, 16, 14, 37, 755).AddTicks(4636),
                UpdatedDate = new DateTime(2022, 3, 30, 16, 14, 37, 758).AddTicks(1509)
            };

            var guest = new User
            {
                Id = Guid.Parse("d6df6771-ef40-4713-81d5-a0429cd34ab9"),
                Email = "guest@gmail.com",
                Password = "guest",
                Role = "guest",
                Username = "guest",
                CreatedDate = new DateTime(2022, 3, 30, 16, 14, 37, 755, DateTimeKind.Utc).AddTicks(4636),
                UpdatedDate = new DateTime(2022, 3, 30, 16, 14, 37, 758, DateTimeKind.Utc).AddTicks(1509)
            };

            builder.Entity<User>().HasData(user1, guest);
        }
    }
}