using Booking.Domain.Base;

namespace Booking.Domain.Reservations
{
    public class Reservation : Entity
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid UserId { get; set; }

        public Guid RoomId { get; set; }

        public bool IsActive { get; set; }
    }
}
