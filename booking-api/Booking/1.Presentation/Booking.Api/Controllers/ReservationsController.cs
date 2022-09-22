using Microsoft.AspNetCore.Mvc;
using Booking.Api.DTOs;
using Booking.Domain.Exceptions;
using Booking.Application.Interfaces;
using Booking.Application.Contracts;

namespace Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ApiControllerBase
    {
        private readonly IReservationService _service;

        public ReservationsController(IReservationService reservationService

            )
        {
            _service = reservationService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateReservationResponse>> CreateReservation([FromBody] CreateReservationDTO dto)
        {
            try
            {
                var response = await _service.AddAsync(new CreateReservationRequest
                {
                    StartDate = dto.StartDate,
                    EndDate = dto.EndDate,
                    RoomId = Guid.Parse(dto.RoomId),
                    UserId = Guid.Parse(dto.UserId),
                });

                return Ok(response);
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

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Response<UpdateReservationResponse>>> UpdateReservation([FromBody] UpdateReservationDTO dto, [FromRoute] string id)
        {
            try
            {

                var response = await _service.UpdateAsync(new UpdateReservationRequest
                {
                    StartDate = dto.StartDate,
                    EndDate = dto.EndDate,
                    RoomId = Guid.Parse(dto.RoomId),
                    ReservationId = Guid.Parse(id),
                });

                return Ok(response);
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

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<dynamic>> CancelReservation([FromRoute] string id)
        {
            try
            {
                var response = await _service.CancelAsync(new CancelReservationRequest
                {
                    ReservationId = Guid.Parse(id),
                });

                return Ok(response);
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
        public async Task<ActionResult<dynamic>> Get()
        {
            try
            {
                var response = _service.Get();

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }
    }
}
