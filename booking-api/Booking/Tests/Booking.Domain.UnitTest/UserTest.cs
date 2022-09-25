using Booking.Domain.Exceptions;
using Booking.Domain.Reservations;
using Booking.Domain.Users;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Booking.Domain.UnitTest
{
    public class UserTest
    {
        [Fact]
        public void CreateInstance_WithValidInformation_ShouldCreateWithoutError()
        {
            var user = new User("teste@test.com","test","test","user");
        
            user.Id.Should().NotBeEmpty();
        }
    }
}
