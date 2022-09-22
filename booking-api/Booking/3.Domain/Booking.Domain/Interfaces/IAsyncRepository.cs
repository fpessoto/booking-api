using Booking.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Interfaces
{
    public interface IAsyncRepository<T> where T : Entity
    {
        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<T> GetByIdAsync(Guid userId);

        IQueryable<T> GetAllAsync();

        IQueryable<T> Get(Expression<Func<T, bool>> expression);
    }
}
