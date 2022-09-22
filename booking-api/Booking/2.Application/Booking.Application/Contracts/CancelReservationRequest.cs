using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Contracts
{
    public class CancelReservationRequest
    {
        public Guid ReservationId { get; set; }
    }
}
