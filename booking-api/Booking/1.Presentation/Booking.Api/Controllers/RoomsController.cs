using Booking.Application.Contracts;
using Booking.Application.Interfaces;
using Booking.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ApiControllerBase
    {
        private readonly IRoomService _roomservice;

        public RoomsController(IRoomService roomservice)
        {
            this._roomservice = roomservice;
        }

        [HttpGet]
        [Route("AvailableDates/{roomId}")]
        public async Task<ActionResult<AvailableDatesResponse>> Get([FromRoute] string roomId)
        {
            try
            {
                var dates = await _roomservice.GetAvailableDates(Guid.Parse(roomId));

                return Ok(dates);
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
        public async Task<ActionResult<IList<RoomResponse>>> Get()
        {
            try
            {
                var rooms = await _roomservice.Get();

                return Ok(rooms);
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
