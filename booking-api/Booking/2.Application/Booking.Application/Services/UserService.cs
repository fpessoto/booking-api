using Booking.Application.Contracts;
using Booking.Application.Interfaces;
using Booking.Domain.Exceptions;
using Booking.Domain.Users;

namespace Booking.Application.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Response<UserResponse>> Create(CreateUserRequest request)
        {
            var existentUser = (await _userRepository.GetAsync(request.Email));

            if (existentUser != null) throw new EmailAlreadyExistsException("This e-mail already exists! Try another one.");

            var user = new User(request.Email, request.Password, request.Username, "user");

            await _userRepository.AddAsync(user);

            return new Response<UserResponse>
            {
                IsSuccess = true,
                Body = new UserResponse
                {
                    Email = user.Email,
                    UserId = user.Id,
                    Username = user.Username,
                }
            };
        }

        public async Task<IList<UserResponse>> GetAll()
        {
            var response = (_userRepository.GetAllAsync()).ToList();

            IEnumerable<UserResponse> users = response.Select(u => new UserResponse
            {
                Username = u.Username,
                Email = u.Email,
                UserId = u.Id,
            });

            return users.ToList();
        }
    }
}
