using Booking.Domain.Enums;
using System.Runtime.Serialization;

namespace Booking.Domain.Exceptions
{
    public class EmailAlreadyExistsException : BusinessException
    {
        public EmailAlreadyExistsException() : base(ErrorCodes.AlreadyExists, "")
        {
        }

        public EmailAlreadyExistsException(string? message) : base(ErrorCodes.AlreadyExists, message)
        {
        }

    }
}
