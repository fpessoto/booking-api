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

        public Reservation(DateTime startDate, DateTime endDate, Guid userId, Guid roomId)
        {
            ValidationRangeDate(startDate, endDate);

            Id = Guid.NewGuid();
            SetStartDate(startDate);
            SetEndDate(endDate);
            UserId = userId;
            RoomId = roomId;
            IsActive = true;
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
        }


        public void Update(DateTime startDate, DateTime endDate, Guid roomId)
        {
            ValidationRangeDate(startDate, endDate);

            SetStartDate(startDate);
            SetEndDate(endDate);
            RoomId = roomId;
            UpdatedDate = DateTime.UtcNow;
        }

        public void Cancel()
        {
            if (!IsActive) throw new BusinessException(ErrorCodes.Forbidden, "This reservation is already canceled");
            IsActive = false;
        }

        private void SetStartDate(DateTime date)
        {
            StartDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0, DateTimeKind.Utc);
        }


        private void SetEndDate(DateTime date)
        {
            EndDate = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999, DateTimeKind.Utc);
        }

        private void ValidationRangeDate(DateTime startDate, DateTime endDate)
        {
            if (startDate.Date > endDate.Date) throw new BusinessException(ErrorCodes.Forbidden, "'End Date' should be greater than 'Start Date'");
            if (startDate.Date.AddDays(3) <= endDate.Date) throw new BusinessException(ErrorCodes.Forbidden, "The reservation period can not be longer than 3 days");
            if (startDate.Date >= DateTime.Today.AddDays(30).Date ) throw new BusinessException(ErrorCodes.Forbidden, "The reservation can not be made with 30 days in advance");
        }

    }
}
