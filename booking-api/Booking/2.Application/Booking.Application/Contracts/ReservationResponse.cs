using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Contracts
{
    [ExcludeFromCodeCoverage]
    public class ReservationResponse
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid RoomId { get; set; }

        public bool IsActive { get; set; }
    }
}
