using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Booking.Api.DTOs;
using Booking.Api.ViewModels;
using Booking.Application.Commands;
using Booking.Domain.Exceptions;

namespace Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ApiControllerBase
    {


        public ReservationsController(

            )
        {


        }

        [HttpPost]
        //[Authorize(Roles = "user")]
        public async Task<ActionResult<dynamic>> CreateReservation([FromBody] CreateReservationDTO model)
        {
            try
            {
                //var player = await _updatePlayer.ExecuteAsync(new UpdatePlayerCommand
                //{
                //    PlayerId = id,
                //    FirstName = model.FirstName,
                //    LastName = model.LastName,
                //    Country = model.Country,
                //    UserId = UserId
                //});

                //return Ok(player.ToViewModel());
                return Ok();
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("{id}")]
        //[Authorize(Roles = "user")]
        public async Task<ActionResult<dynamic>> UpdateReservation([FromBody] UpdateReservationDTO model, [FromRoute] Guid id)
        {
            try
            {

                return Ok();
            }
            catch (BusinessException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        [HttpGet]
        [Route("")]
        //[Authorize(Roles = "user")]
        public async Task<ActionResult<dynamic>> Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
    }
}
