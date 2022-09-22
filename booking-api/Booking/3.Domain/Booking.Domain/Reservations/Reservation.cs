using Booking.Domain.Base;
using Booking.Domain.Enums;
using Booking.Domain.Exceptions;

namespace Booking.Domain.Reservations
{
    public class Reservation : Entity
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid UserId { get; set; }

        public Guid RoomId { get; set; }

        public bool IsActive { get; private set; }

        public Reservation() { }

        public Reservation(DateTime startDate, DateTime endDate, Guid userId, Guid roomId)
        {
            ValidationRangeDate(startDate, endDate);

            Id = Guid.NewGuid();
            StartDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0, 0);
            EndDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59, 999);
            UserId = userId;
            RoomId = roomId;
            IsActive = true;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        private void ValidationRangeDate(DateTime startDate, DateTime endDate)
        {
            if (startDate.Date >= endDate.Date) throw new BusinessException(ErrorCodes.Forbidden, "'End Date' should be greater than 'Start Date'");
            if (endDate.Date.Subtract(startDate.Date).TotalDays > 3) throw new BusinessException(ErrorCodes.Forbidden, "The reservation period can not be longer than 3 days");
            if (endDate.Date.Subtract(startDate.Date).TotalDays > 3) throw new BusinessException(ErrorCodes.Forbidden, "The reservation period can not be longer than 3 days");
            if (startDate.Date.Subtract(DateTime.Now.Date).TotalDays > 30) throw new BusinessException(ErrorCodes.Forbidden, "The reservation can not be made with 30 days in advance");
        }

        public void Update(DateTime startDate, DateTime endDate, Guid roomId)
        {
            ValidationRangeDate(startDate, endDate);

            StartDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0, 0);
            EndDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59, 999);
            RoomId = roomId;
            UpdatedDate = DateTime.Now;
        }

        public void Cancel()
        {
            if (!IsActive) throw new BusinessException(ErrorCodes.Forbidden, "This reservation is already canceled");
            IsActive = false;
        }

    }
}
