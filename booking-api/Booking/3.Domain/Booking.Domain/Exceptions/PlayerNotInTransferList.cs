using System.Runtime.Serialization;

namespace Booking.Domain.Exceptions
{
    public class PlayerNotInTransferList : Exception
    {
        public PlayerNotInTransferList()
        {
        }

        public PlayerNotInTransferList(string? message) : base(message)
        {
        }

        public PlayerNotInTransferList(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PlayerNotInTransferList(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}