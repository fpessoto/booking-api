namespace Booking.Api.DTOs
{
    public class CreateReservationDTO
    {
        public string UserId { get; set; }

        public string RoomId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
