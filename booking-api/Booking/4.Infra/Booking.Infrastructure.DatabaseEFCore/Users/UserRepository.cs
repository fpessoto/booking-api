using Microsoft.EntityFrameworkCore;
using Booking.Domain.Users;
using Booking.Infrastructure.DatabaseEFCore.Context;
using System.Linq.Expressions;

namespace Booking.Infrastructure.DatabaseEFCore.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly BookingDBContext _context;

        public UserRepository(BookingDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User entity)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<User> GetAllAsync()
        {
            return _context.Users.AsNoTracking();
        }

        public IQueryable<User> Get(Expression<Func<User, bool>> expression)
        {
            var usersQueryable = _context.Users.AsNoTracking().Where(expression).AsQueryable();

            return usersQueryable;
        }

        public async Task<User> GetByIdAsync(Guid userId)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId);
        }

        public  async Task<User?> GetAsync(string email, string password)
        {
            return await _context.Users.AsNoTracking().FirstAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<User?> GetAsync(string email)
        {
            return await _context.Users.FirstAsync(u => u.Email == email);
        }
    }
}
