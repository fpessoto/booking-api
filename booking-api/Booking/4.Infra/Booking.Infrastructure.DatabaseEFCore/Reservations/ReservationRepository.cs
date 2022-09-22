using Booking.Domain.Reservations;
using Booking.Infrastructure.DatabaseEFCore.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Reservation entity)
        {
            _context.Reservations.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Reservation entity)
        {
            _context.Reservations.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Reservation> GetAllAsync()
        {
            return _context.Reservations.AsQueryable();
        }

        public IQueryable<Reservation> Get(Expression<Func<Reservation, bool>> expression)
        {
            var queryable = _context.Reservations.Where(expression).AsQueryable();

            return queryable;
        }

        public async Task<Reservation> GetByIdAsync(Guid reservationId)
        {
            return await _context.Reservations.Where(x => x.Id == reservationId).FirstOrDefaultAsync();
        }        
    }
}
