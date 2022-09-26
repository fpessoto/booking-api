using Booking.Application.Contracts;
using Booking.Application.Services;
using Booking.Domain.Exceptions;
using Booking.Domain.Reservations;
using Booking.Domain.Rooms;
using Booking.Domain.Users;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Booking.Application.UnitTest
{
    public class RoomServiceTest 
    {
        private Mock<IRoomRepository> _roomRepositoryMock;
        private readonly Mock<IReservationRepository> _reservationRepositoryMock;
        private readonly RoomService _sut;

        public RoomServiceTest()
        {
            _roomRepositoryMock = new Mock<IRoomRepository>();
            _reservationRepositoryMock = new Mock<IReservationRepository>();

            _sut = new RoomService(_roomRepositoryMock.Object, _reservationRepositoryMock.Object);
        }

        [Fact]
        public async Task Get_Should_ReturnReservationList()
        {

            var rooms = new List<Room>
            {
                new Room()
            };

            _roomRepositoryMock.Setup(x => x.GetAllAsync()).Returns(rooms.AsQueryable());

            var response = await _sut.Get();

            response.Count.Should().Be(rooms.Count);
        }

        [Fact]
        public async Task GetAvailableDates_Should_ReturnNext30DaysAvailable()
        {
            var roomId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var initialDate = DateTime.Today;

            var reservations = new List<Reservation>{
                new Reservation(initialDate, initialDate.AddDays(1), userId, roomId),
                new Reservation(initialDate.AddDays(2), initialDate.AddDays(3), userId, roomId),
                new Reservation(initialDate.AddDays(5), initialDate.AddDays(5), userId, roomId)
            };

            _reservationRepositoryMock.Setup(r=> r.Get(It.IsAny<Expression<Func<Reservation, bool>>>()))
                                       .Returns(reservations.AsQueryable());

            var response = await _sut.GetAvailableDates(roomId);

            response.AvailableDates.Count().Should().BeGreaterThan(0);
        }
    }
}
