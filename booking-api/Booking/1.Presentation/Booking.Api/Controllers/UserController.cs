using Microsoft.AspNetCore.Mvc;
using Booking.Api.DTOs;
using Booking.Domain.Exceptions;
using Booking.Application.Interfaces;
using Booking.Application.Contracts;

namespace Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IUserService UserService { get; }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<dynamic>> Create([FromBody] UserCreateDTO dto)
        {
            try
            {
                var request = new CreateUserRequest
                {
                    Email = dto.Email,
                    Password = dto.Password,
                    Username = dto.Username
                };

                var newUser = await _userService.Create(request);

                return Ok(newUser);
            }
            catch (BusinessException e)
            {
                return BadRequest(new { message = e.Message });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IList<UserResponse>>> Get()
        {
            try
            {
                var users = await _userService.GetAll();

                return Ok(users);
            }
            catch (BusinessException e)
            {
                return BadRequest(new { message = e.Message });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
