using Booking.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Interfaces
{
    public interface IUserService
    {
        Task<Response<UserResponse>> Create(CreateUserRequest request);

        Task<IList<UserResponse>> GetAll();
    }
}
