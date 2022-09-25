using System.Diagnostics.CodeAnalysis;

namespace Booking.Domain.Base
{
    [ExcludeFromCodeCoverage]
    public abstract class Entity
    {
        public virtual Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
