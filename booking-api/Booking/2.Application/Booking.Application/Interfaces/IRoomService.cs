using Booking.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Interfaces
{
    public interface IRoomService
    {
        Task<IList<RoomResponse>> Get();

        Task<AvailableDatesResponse> GetAvailableDates(Guid roomId);
    }
}
