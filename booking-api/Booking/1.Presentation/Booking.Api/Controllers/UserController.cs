//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Booking.Api.DTOs;
//using Booking.Api.Services;
//using Booking.Api.ViewModels;
//using Booking.Application.Commands;
//using Booking.Domain.Exceptions;
//using Booking.Domain.Users;

//namespace Booking.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly IUserRepository _userRepository;
//        ICommand<UserSignupCommand, User> _signupCommand;

//        public UserController(IUserRepository userRepository, ICommand<UserSignupCommand, User> command)
//        {
//            _userRepository = userRepository;
//            _signupCommand = command;
//        }

//        [HttpPost]
//        [Route("signup")]
//        public async Task<ActionResult<dynamic>> Signup([FromBody] UserAuth model)
//        {
//            try
//            {
//                var cmd = new UserSignupCommand
//                {
//                    Email = model.Email,
//                    Password = model.Password,
//                    Username = model.Email
//                };

//                var newUser = await _signupCommand.ExecuteAsync(cmd);
//                newUser.Password = "";

//                return Ok(newUser);
//            }
//            catch (BusinessException e)
//            {
//                return BadRequest(e.Message);
//            }
//            catch (Exception)
//            {
//                return StatusCode(500);
//            }
//        }

//        [HttpPost]
//        [Route("login")]
//        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserAuth model)
//        {
//            try
//            {
//                // Recupera o usuário
//                var user = await _userRepository.GetAsync(model.Email, model.Password);

//                // Verifica se o usuário existe
//                if (user == null)
//                    return NotFound(new { message = "Usuário ou senha inválidos" });

//                // Gera o Token
//                var token = TokenService.GenerateToken(user);

//                // Oculta a senha
//                user.Password = "";

//                // Retorna os dados
//                return Ok(new
//                {
//                    user = user.ToViewModel(),
//                    token = token
//                });
//            }
//            catch (BusinessException e)
//            {
//                return BadRequest(e.Message);
//            }
//            catch (Exception)
//            {
//                return StatusCode(500);
//            }
//        }
//    }
//}
