using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Rooms
{
    public interface IRoomRepository
    {
        Task<Room> GetByIdAsync(Guid userId);

        IQueryable<Room> GetAllAsync();
    }
}
