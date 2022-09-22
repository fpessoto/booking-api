using Booking.Application.Contracts;
using Booking.Application.Interfaces;
using Booking.Domain.Exceptions;
using Booking.Domain.Reservations;
using Booking.Domain.Users;

namespace Booking.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IUserRepository _userRepository;

        public ReservationService(IReservationRepository reservationRepository, IUserRepository userRepository)
        {
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
        }

        public async Task<Response<CreateReservationResponse>> AddAsync(CreateReservationRequest request)
        {
            var response = new Response<CreateReservationResponse> { IsSuccess = true };

            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null) throw new UserNotFoundException("User not found");

            await ValidateExistentReservation(request.StartDate, request.EndDate, request.RoomId);

            var reservation = new Reservation(request.StartDate, request.EndDate, request.UserId, request.RoomId);

            await _reservationRepository.AddAsync(reservation);

            response.Body = new CreateReservationResponse { ReservationdId = reservation.Id };

            return response;
        }

        public async Task<Response<CancelReservationResponse>> CancelAsync(CancelReservationRequest request)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.ReservationId);

            if (reservation == null) throw new BusinessException(Domain.Enums.ErrorCodes.Forbidden, "Reservation not found");

            reservation.Cancel();

            await _reservationRepository.UpdateAsync(reservation);

            return new Response<CancelReservationResponse>
            {
                IsSuccess = true
            };
        }

        public List<ReservationResponse> Get()
        {
            var reservation = _reservationRepository.GetAllAsync().Select(r => new ReservationResponse
            {
                EndDate = r.EndDate,
                RoomId = r.RoomId,
                Id = r.Id,
                IsActive = r.IsActive,
                StartDate = r.StartDate
            });

            return reservation.ToList();
        }

        public async Task<Response<UpdateReservationResponse>> UpdateAsync(UpdateReservationRequest request)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.ReservationId);

            if (reservation == null) throw new BusinessException(Domain.Enums.ErrorCodes.Forbidden, "Reservation not found");

            await ValidateExistentReservation(request.StartDate, request.EndDate, request.RoomId);

            reservation.Update(request.StartDate, request.EndDate, request.RoomId);

            await _reservationRepository.UpdateAsync(reservation);

            return new Response<UpdateReservationResponse>
            {
                IsSuccess = true
            };
        }

        private async Task ValidateExistentReservation(DateTime startDate, DateTime endDate, Guid roomId)
        {
            IQueryable<Reservation> queryable = (_reservationRepository
                                                            .GetAllAsync());
            var existentReservations = queryable.Where(x =>
                                                                (x.RoomId == roomId && x.IsActive == true) && (
                                                                (x.EndDate >= startDate && x.EndDate <= endDate) ||
                                                                (x.StartDate >= startDate && x.StartDate <= endDate)
                                                                )
                                                          );

            if (existentReservations.Any()) throw new BusinessException(Domain.Enums.ErrorCodes.Forbidden, "Invalid dates! Reservation already exists for this period!");
        }
    }
}
