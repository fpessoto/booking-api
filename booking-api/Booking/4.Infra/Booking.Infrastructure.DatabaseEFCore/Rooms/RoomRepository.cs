using Booking.Domain.Rooms;
using Booking.Infrastructure.DatabaseEFCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.DatabaseEFCore.Rooms
{
    public class RoomRepository : IRoomRepository
    {
        private readonly BookingDBContext _context;

        public RoomRepository(BookingDBContext context)
        {
            _context = context;
        }

        public IQueryable<Room> GetAllAsync()
        {
            return _context.Rooms.AsQueryable();
        }

        public async Task<Room> GetByIdAsync(Guid id)
        {
            return await _context.Rooms.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
