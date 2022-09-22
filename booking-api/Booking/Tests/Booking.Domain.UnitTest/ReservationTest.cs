using Booking.Domain.Exceptions;
using Booking.Domain.Reservations;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Booking.Domain.UnitTest
{
    public class ReservationTest
    {
        [Fact]
        public void CreateInstance_WithValidInformation_ShouldCreateWithoutError()
        {
            var userId = Guid.NewGuid();
            var roomId = Guid.NewGuid();

            var resertation = new Reservation(new DateTime(2022, 1, 11), new DateTime(2022, 1, 12), userId, roomId);

            resertation.IsActive.Should().BeTrue();
        }


        [Fact]
        public void Cancel_WithValidInformation_ShouldChangeToInactive()
        {
            var userId = Guid.NewGuid();
            var roomId = Guid.NewGuid();

            var resertation = new Reservation(new DateTime(2022, 1, 11), new DateTime(2022, 1, 12), userId, roomId);
            resertation.Cancel();

            resertation.IsActive.Should().BeFalse();
        }

        [Fact]
        public void Cancel_WithInvalidInformation_ShouldThrowBusinessException()
        {
            var userId = Guid.NewGuid();
            var roomId = Guid.NewGuid();

            var resertation = new Reservation(new DateTime(2022, 1, 11), new DateTime(2022, 1, 12), userId, roomId);
            resertation.Cancel();

            var ex = Assert.Throws<BusinessException>(() => resertation.Cancel());
            ex.Message.Should().Be("This reservation is already canceled");

            resertation.IsActive.Should().BeFalse();
        }

    }
}
