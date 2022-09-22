using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Contracts
{
    public class UserResponse
    {
        public Guid UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}
