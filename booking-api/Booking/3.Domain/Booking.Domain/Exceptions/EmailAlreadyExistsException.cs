using System.Diagnostics.CodeAnalysis;
using Booking.Domain.Enums;

namespace Booking.Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class EmailAlreadyExistsException : BusinessException
    {
        public EmailAlreadyExistsException() : base(ErrorCodes.AlreadyExists, "")
        {
        }

        public EmailAlreadyExistsException(string message) : base(ErrorCodes.AlreadyExists, message)
        {
            if(message == null) throw new ArgumentException(); 
        }

    }
}
