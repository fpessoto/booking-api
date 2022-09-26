using Booking.Application.Contracts;
using Booking.Application.Services;
using Booking.Domain.Exceptions;
using Booking.Domain.Reservations;
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
    public class ReservationServiceTest 
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IReservationRepository> _reservationRepositoryMock;
        private readonly ReservationService _sut;

        public ReservationServiceTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _reservationRepositoryMock = new Mock<IReservationRepository>();

            _sut = new ReservationService(_reservationRepositoryMock.Object, _userRepositoryMock.Object);
        }

        [Fact]
        public async Task AddAsync_WithValidRequest_ShouldCreateReservationWithSuccess()
        {
            var userId = Guid.NewGuid();
            var roomId = Guid.NewGuid();

            var request = new CreateReservationRequest
            {
                StartDate = new DateTime(2022, 1, 2),
                EndDate = new DateTime(2022, 1, 4),
                RoomId = roomId,
                UserId = userId,
            };

            var reservation = new List<Reservation>
            {
                new Reservation(new DateTime(2022, 1, 11), new DateTime(2022, 1, 12), userId, roomId)
            };

            _userRepositoryMock.Setup(x => x.GetByIdAsync(userId)).ReturnsAsync(new User { Id = userId });

            _reservationRepositoryMock.Setup(x => x.GetAllAsync()).Returns(reservation.AsQueryable());

            var response = await _sut.AddAsync(request);

            response.IsSuccess.Should().BeTrue();
            response.Body.ReservationdId.Should().NotBeEmpty();
        }


        [Fact]
        public async Task AddAsync_WithExistentReservation_ShouldThrowBusinessException()
        {
            await AddExistentReservation(new DateTime(2022, 1, 1), new DateTime(2022, 1, 2), new DateTime(2022, 1, 2), new DateTime(2022, 1, 4));
            await AddExistentReservation(new DateTime(2022, 1, 1), new DateTime(2022, 1, 3), new DateTime(2022, 1, 2), new DateTime(2022, 1, 4));
            await AddExistentReservation(new DateTime(2022, 1, 3), new DateTime(2022, 1, 5), new DateTime(2022, 1, 2), new DateTime(2022, 1, 4));
            await AddExistentReservation(new DateTime(2022, 1, 4), new DateTime(2022, 1, 6), new DateTime(2022, 1, 2), new DateTime(2022, 1, 4));
        }

        [Fact]
        public async Task AddAsync_WithInvalidUser_ShouldThrowBusinessException()
        {
            var userId = Guid.NewGuid();
            var roomId = Guid.NewGuid();

            var request = new CreateReservationRequest
            {
                StartDate = new DateTime(2022, 1, 2),
                EndDate = new DateTime(2022, 1, 4),
                RoomId = roomId,
                UserId = userId,
            };

            User user = null;

            _userRepositoryMock.Setup(x => x.GetByIdAsync(userId)).ReturnsAsync(user);


            var ex = await Assert.ThrowsAsync<UserNotFoundException>(
                async () => await _sut.AddAsync(request));
            ex.Message.Should().Be("User not found");
        }

        [Fact]
        public async Task CancelAsync_WithInvaliReservation_ShouldThrowBusinessException(){

            var request = new CancelReservationRequest{
                ReservationId = Guid.NewGuid()
            };

              var ex = await Assert.ThrowsAsync<BusinessException>(
                async () => await _sut.CancelAsync(request));
            ex.Message.Should().Be("Reservation not found");
        }

        [Fact]
        public async Task CancelAsync_ValidData_ShouldCancelWithSuccess(){

            var request = new CancelReservationRequest{
                ReservationId = Guid.NewGuid()
            };

            var reservartion = CreateValidReservation();

            _reservationRepositoryMock.Setup(x=> x.GetByIdAsync( It.IsAny<Guid>())).ReturnsAsync(reservartion);

            var response = await _sut.CancelAsync(request);

            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task UpdateAsync_WithValidRequest_ShouldUpdateReservationWithSuccess()
        {
            var userId = Guid.NewGuid();
            var roomId = Guid.NewGuid();

            var reservartion = CreateValidReservation();

            var request = new UpdateReservationRequest
            {
                StartDate = new DateTime(2022, 1, 2),
                EndDate = new DateTime(2022, 1, 4),
                RoomId = roomId,
                ReservationId = reservartion.Id
            };

            var reservations = new List<Reservation>
            {
                new Reservation(new DateTime(2022, 1, 11), new DateTime(2022, 1, 12), userId, roomId)
            };

            _reservationRepositoryMock.Setup(x=> x.GetByIdAsync( It.IsAny<Guid>())).ReturnsAsync(reservartion);

            _reservationRepositoryMock.Setup(x => x.GetAllAsync()).Returns(reservations.AsQueryable());

            var response = await _sut.UpdateAsync(request);

            response.IsSuccess.Should().BeTrue();
        }

        [Fact]

        public async Task Update_WithInvalidReservation_ShouldThrowNotFoundException(){
            var userId = Guid.NewGuid();
            var roomId = Guid.NewGuid();
            var reservartion = CreateValidReservation();

            var request = new UpdateReservationRequest
            {
                StartDate = reservartion.StartDate,
                EndDate = reservartion.EndDate,
                RoomId = roomId,
                ReservationId = reservartion.Id
            };

            var ex = await Assert.ThrowsAsync<BusinessException>(
                async () => await _sut.UpdateAsync(request));
            ex.Message.Should().Be("Reservation not found");
        }

         [Fact]
        public async Task Update_WithExistentReservation_ShouldThrowBusinessException()
        {
            await UpdateExistentReservation(new DateTime(2022, 1, 1), new DateTime(2022, 1, 3), new DateTime(2022, 1, 2), new DateTime(2022, 1, 4));
            await UpdateExistentReservation(new DateTime(2022, 1, 3), new DateTime(2022, 1, 5), new DateTime(2022, 1, 2), new DateTime(2022, 1, 4));
            await UpdateExistentReservation(new DateTime(2022, 1, 4), new DateTime(2022, 1, 6), new DateTime(2022, 1, 2), new DateTime(2022, 1, 4));
            await UpdateExistentReservation(new DateTime(2022, 1, 1), new DateTime(2022, 1, 2), new DateTime(2022, 1, 2), new DateTime(2022, 1, 4));
        }

         [Fact]
        public async Task Get_Should_ReturnReservationList()
        {

            var reservation = new List<Reservation>
            {
                CreateValidReservation(),
                CreateValidReservation(),
            };

            _reservationRepositoryMock.Setup(x => x.GetAllAsync()).Returns(reservation.AsQueryable());

            var response = _sut.Get();

            response.Count.Should().Be(reservation.Count);
        }

        private async Task AddExistentReservation(DateTime existentStartDate, DateTime existentEndDate, DateTime reservationStartDate, DateTime reservationEndDate)
        {
            var userId = Guid.NewGuid();
            var roomId = Guid.NewGuid();

            var request = new CreateReservationRequest
            {
                StartDate = reservationStartDate,
                EndDate = reservationEndDate,
                RoomId = roomId,
                UserId = userId,
            };

            var reservation = new List<Reservation>
            {
                new Reservation( existentStartDate, existentEndDate, userId, roomId)
            };

            _userRepositoryMock.Setup(x => x.GetByIdAsync(userId)).ReturnsAsync(new User { Id = userId });

            _reservationRepositoryMock.Setup(x => x.GetAllAsync()).Returns(reservation.AsQueryable());

            var ex = await Assert.ThrowsAsync<BusinessException>(
                async () => await _sut.AddAsync(request));
            ex.Message.Should().Be("Invalid dates! Reservation already exists for this period!");
        }

        private async Task UpdateExistentReservation(DateTime existentStartDate, DateTime existentEndDate, DateTime reservationStartDate, DateTime reservationEndDate)
        {
            var userId = Guid.NewGuid();
            var roomId = Guid.NewGuid();
            var reservartion = CreateValidReservation();

            var request = new UpdateReservationRequest
            {
                StartDate = reservationStartDate,
                EndDate = reservationEndDate,
                RoomId = roomId,
                ReservationId = reservartion.Id
            };

            var reservation = new List<Reservation>
            {
                new Reservation( existentStartDate, existentEndDate, userId, roomId)
            };


            _reservationRepositoryMock.Setup(x=> x.GetByIdAsync( It.IsAny<Guid>())).ReturnsAsync(reservartion);


            _reservationRepositoryMock.Setup(x => x.GetAllAsync()).Returns(reservation.AsQueryable());

            var ex = await Assert.ThrowsAsync<BusinessException>(
                async () => await _sut.UpdateAsync(request));
            ex.Message.Should().Be("Invalid dates! Reservation already exists for this period!");
        }

        private Reservation CreateValidReservation(){
            return new Reservation(new DateTime(2022, 1, 1), new DateTime(2022, 1, 2), Guid.NewGuid(), Guid.NewGuid());
        }

        public void Dispose()
        {
        }
    }
}
