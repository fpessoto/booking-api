namespace Booking.Application.Contracts
{
    public class Response<T>
    {
        public string? Message { get; set; }

        public bool IsSuccess { get; set; }

        public T Body { get; set; }
    }
}
