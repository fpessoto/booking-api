using System.Diagnostics.CodeAnalysis;

namespace Booking.Application.Contracts
{
    [ExcludeFromCodeCoverage]
    public class AvailableDatesResponse
    {
        public Guid RoomId { get; set; }

        public IList<DateTime> AvailableDates { get; set; }
    }
}
