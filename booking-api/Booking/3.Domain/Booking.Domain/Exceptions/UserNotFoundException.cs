using System.Runtime.Serialization;

namespace Booking.Domain.Exceptions
{
    public class UserNotFoundException : BusinessException
    {
        public UserNotFoundException(string? message) : base(Enums.ErrorCodes.NotFound, message)
        {
        }

    }
}
