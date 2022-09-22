namespace Booking.Api.DTOs
{
    public class UpdateReservationDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RoomId { get; set; }
    }
}
