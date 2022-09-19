using System.Runtime.Serialization;

namespace Booking.Domain.Exceptions
{
    public class NotEnoughtBudgetException : BusinessException
    {
        public NotEnoughtBudgetException() : base(Enums.ErrorCodes.InvalidObject, "Not enough budget")
        {
        }

        public NotEnoughtBudgetException(string? message) : base(Enums.ErrorCodes.InvalidObject, message)
        {
        }
    }
}
