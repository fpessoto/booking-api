using Booking.Domain.Rooms;
using FluentAssertions;
using Xunit;

namespace Booking.Domain.UnitTest
{
    public class RoomTest
    {
        [Fact]
        public void CreateInstance_WithValidInformation_ShouldCreateWithoutError()
        {
            var room = new Room{Description= "beautiful room"};
        
            room.Id.Should().NotBeEmpty();
        }
    }
}
