using Booking.Application.Contracts;
using Booking.Application.Interfaces;
using Booking.Domain.Reservations;
using Booking.Domain.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IReservationRepository _reservationRepository;

        public RoomService(IRoomRepository roomRepository, IReservationRepository reservationRepository)
        {
            _roomRepository = roomRepository;
            _reservationRepository = reservationRepository;
        }
        public async Task<IList<RoomResponse>> Get()
        {
            var rooms = (_roomRepository.GetAllAsync()).ToList();

            IEnumerable<RoomResponse> roomsResponse = rooms.Select(r => new RoomResponse
            {
                Id = r.Id,
                Description = r.Description
            });
            return roomsResponse.ToList();
        }

        public async Task<AvailableDatesResponse> GetAvailableDates(Guid roomId)
        {
            var response = new AvailableDatesResponse { RoomId = roomId, AvailableDates = new List<DateTime>() };

            var qtAvailableDates = 30;

            var startDate = DateTime.Now.Date;
            var endDate = DateTime.Now.Date.AddDays(qtAvailableDates);

            var reservationsQueryable = (_reservationRepository.Get(r => r.RoomId == roomId && r.IsActive == true));
            var reservations = reservationsQueryable.OrderBy(r => r.StartDate).ToList();

            for (int i = 0; i < qtAvailableDates; i++)
            {
                response.AvailableDates.Add(startDate.Date);
                startDate = startDate.AddDays(1);
            }

            foreach (var reservation in reservations)
            {
                var dateToRemove = reservation.StartDate.Date;
                var days = reservation.EndDate.Date.Subtract(reservation.StartDate.Date).Days;
                if (reservation.StartDate.Date == reservation.EndDate.Date)
                {
                    response.AvailableDates.Remove(dateToRemove);
                }
                else
                {
                    for (int i = 0; i <= days; i++)
                    {
                        response.AvailableDates.Remove(dateToRemove);
                        dateToRemove = dateToRemove.AddDays(1);
                    }
                }
            }

            return response;
        }
    }
}
