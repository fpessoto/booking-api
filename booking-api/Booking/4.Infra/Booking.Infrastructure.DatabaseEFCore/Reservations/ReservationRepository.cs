using Booking.Domain.Reservations;
using Booking.Infrastructure.DatabaseEFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.DatabaseEFCore.Reservations
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly BookingDBContext _context;

        public ReservationRepository(BookingDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Reservation entity)
        {
            await _context.Reservations.AddAsync(entity);
        }

        public Task DeleteAsync(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Reservation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Reservation>> GetAsync(Expression<Func<Reservation, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Reservation entity)
        {
            throw new NotImplementedException();
        }
    }
}
