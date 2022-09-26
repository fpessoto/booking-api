using System.Diagnostics.CodeAnalysis;

namespace Booking.Application.Contracts
{
    [ExcludeFromCodeCoverage]
    public class Response<T>
    {
        public string? Message { get; set; }

        public bool IsSuccess { get; set; }

        public T Body { get; set; }
    }
}
