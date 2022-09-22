using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Contracts
{
    public class AvailableDatesResponse
    {
        public Guid RoomId { get; set; }

        public IList<DateTime> AvailableDates { get; set; }
    }
}
