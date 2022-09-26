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
    public class UserServiceTest 
    {
        private Mock<IUserRepository> _userRepository;
        private readonly UserService _sut;

        public UserServiceTest()
        {
            _userRepository = new Mock<IUserRepository>();

            _sut = new UserService(_userRepository.Object);
        }

        [Fact]
        public async Task Get_Should_ReturnReservationList()
        {
            var users = new List<User>
            {
                new User()
            };

            _userRepository.Setup(x => x.GetAllAsync()).Returns(users.AsQueryable());

            var response = await _sut.GetAll();

            response.Count.Should().Be(users.Count);
        }

        [Fact]
        public async Task Create_WithValidData_ShouldCreateWithSuccess()
        {
           var request = new CreateUserRequest{
            Email = "teste@teste.com",
            Password = "123456",
            Username = "teste"
           };

            var response = await _sut.Create(request);

            response.IsSuccess.Should().BeTrue();
            response.Body.Email.Should().Be(request.Email);
        }

        [Fact]
        public async Task Create_WithInvalidUser_ShouldThrowNotFoundException(){
             var request = new CreateUserRequest{
            Email = "teste@teste.com",
            Password = "123456",
            Username = "teste"
           };

            _userRepository.Setup(u=> u.GetAsync(request.Email)).ReturnsAsync(new User());

            var ex = await Assert.ThrowsAsync<EmailAlreadyExistsException>(
                async () => await _sut.Create(request));
            ex.Message.Should().Be("This e-mail already exists! Try another one.");
        }
    }
}
