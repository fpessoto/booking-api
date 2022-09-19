using Booking.Domain.Interfaces;

namespace Booking.Infrastructure.DatabaseEFCore.Context
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly BookingDBContext _context;

        public UnitOfWork(BookingDBContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
        }
    }
}
