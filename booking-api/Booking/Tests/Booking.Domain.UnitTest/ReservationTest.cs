﻿using Booking.Domain.Exceptions;
using Booking.Domain.Reservations;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Booking.Domain.UnitTest
{
    public class ReservationTest
    {
        [Fact]
        public void CreateInstance_WithValidInformation_ShouldCreateWithoutError()
        {
            var userId = Guid.NewGuid();
            var roomId = Guid.NewGuid();

            var reservatation = new Reservation(new DateTime(2022, 1, 11), new DateTime(2022, 1, 12), userId, roomId);

            reservatation.IsActive.Should().BeTrue();
            reservatation.UserId.Should().Be(userId);
            reservatation.RoomId.Should().Be(roomId);
            
            reservatation.StartDate.Year.Should().Be(2022);
            reservatation.StartDate.Month.Should().Be(1);
            reservatation.StartDate.Day.Should().Be(11);
            reservatation.StartDate.Hour.Should().Be(0);
            reservatation.StartDate.Minute.Should().Be(0);
            reservatation.StartDate.Second.Should().Be(0);
            reservatation.StartDate.Kind.Should().Be(DateTimeKind.Utc);

            reservatation.EndDate.Year.Should().Be(2022);
            reservatation.EndDate.Month.Should().Be(1);
            reservatation.EndDate.Day.Should().Be(12);
            reservatation.EndDate.Hour.Should().Be(23);
            reservatation.EndDate.Minute.Should().Be(59);
            reservatation.EndDate.Second.Should().Be(59);
            reservatation.EndDate.Kind.Should().Be(DateTimeKind.Utc);
        }

        [Fact]
        public void Update_WithValidInformation_ShouldUpdateValuesWithoutError()
        {
            var userId = Guid.NewGuid();
            var roomId = Guid.NewGuid();

            var reservatation = new Reservation(new DateTime(2022, 1, 11), new DateTime(2022, 1, 12), userId, roomId);

            reservatation.Update(new DateTime(2022, 1, 13), new DateTime(2022, 1, 14), roomId);

            reservatation.IsActive.Should().BeTrue();
            reservatation.StartDate.Year.Should().Be(2022);
            reservatation.StartDate.Month.Should().Be(1);
            reservatation.StartDate.Day.Should().Be(13);
            reservatation.StartDate.Hour.Should().Be(0);
            reservatation.StartDate.Minute.Should().Be(0);
            reservatation.StartDate.Second.Should().Be(0);
            reservatation.StartDate.Kind.Should().Be(DateTimeKind.Utc);

            reservatation.EndDate.Year.Should().Be(2022);
            reservatation.EndDate.Month.Should().Be(1);
            reservatation.EndDate.Day.Should().Be(14);
            reservatation.EndDate.Hour.Should().Be(23);
            reservatation.EndDate.Minute.Should().Be(59);
            reservatation.EndDate.Second.Should().Be(59);
            reservatation.EndDate.Kind.Should().Be(DateTimeKind.Utc);
        }


        [Fact]
        public void Cancel_WithValidInformation_ShouldChangeToInactive()
        {
            var userId = Guid.NewGuid();
            var roomId = Guid.NewGuid();

            var resertation = new Reservation(new DateTime(2022, 1, 11), new DateTime(2022, 1, 12), userId, roomId);
            resertation.Cancel();

            resertation.IsActive.Should().BeFalse();
        }

        [Fact]
        public void Cancel_WithInvalidInformation_ShouldThrowBusinessException()
        {
            var userId = Guid.NewGuid();
            var roomId = Guid.NewGuid();

            var resertation = new Reservation(new DateTime(2022, 1, 11), new DateTime(2022, 1, 12), userId, roomId);
            resertation.Cancel();

            var ex = Assert.Throws<BusinessException>(() => resertation.Cancel());
            ex.Message.Should().Be("This reservation is already canceled");

            resertation.IsActive.Should().BeFalse();
        }

    }
}
