using System.Diagnostics.CodeAnalysis;

namespace Booking.Application.Contracts
{
    [ExcludeFromCodeCoverage]
    public class CancelReservationRequest
    {
        public Guid ReservationId { get; set; }
    }
}
