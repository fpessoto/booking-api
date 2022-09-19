namespace Booking.Api.DTOs
{
    public class CreateReservationDTO
    {
        public Guid UserId { get; set; }

        public int RoomId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
