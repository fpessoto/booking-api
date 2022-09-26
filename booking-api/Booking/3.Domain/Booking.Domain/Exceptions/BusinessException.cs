using Booking.Domain.Enums;
using System.Diagnostics.CodeAnalysis;

namespace Booking.Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class BusinessException : Exception
    {
        public BusinessException(ErrorCodes errorCode, string message="") : base(message)
        {
            ErrorCode = errorCode;
        }

        public ErrorCodes ErrorCode { get; }
    }
}
