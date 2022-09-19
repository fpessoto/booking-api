﻿using System.Runtime.Serialization;

namespace Booking.Domain.Exceptions
{
    public class UserAlreadyHasOneTeamException : BusinessException
    {
        public UserAlreadyHasOneTeamException(string? message) : base(Enums.ErrorCodes.AlreadyExists, message)
        {
        }
    }
}
