namespace Booking.Domain.Enums
{
    public enum ErrorCodes
    {
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        AlreadyExists = 409,
        NotAllowed = 405,
        InvalidObject = 422,
        Unhandled = 500,
        ServiceUnavailable = 503,
    }
}
