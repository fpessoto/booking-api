using Booking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Reservations
{
    public interface IReservationRepository : IAsyncRepository<Reservation>
    {
    }
}
