using Booking.Domain.Interfaces;

namespace Booking.Domain.Reservations
{
    public interface IReservationRepository : IAsyncRepository<Reservation>
    {
    }
}
