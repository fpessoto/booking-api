using System.Diagnostics.CodeAnalysis;

namespace Booking.Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class UserNotFoundException : BusinessException
    {
        public UserNotFoundException(string message) : base(Enums.ErrorCodes.NotFound, message)
        {
            if(message == null) throw new ArgumentException();
        }

    }
}
