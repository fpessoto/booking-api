using Booking.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Interfaces
{
    public interface IReservationService
    {
        Task<Response<CreateReservationResponse>> AddAsync(CreateReservationRequest request);

        Task<Response<UpdateReservationResponse>> UpdateAsync(UpdateReservationRequest request);

        Task<Response<CancelReservationResponse>> CancelAsync(CancelReservationRequest request);

        List<ReservationResponse> Get();

    }
}
