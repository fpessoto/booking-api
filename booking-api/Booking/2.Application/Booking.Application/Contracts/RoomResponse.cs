using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Contracts
{
    [ExcludeFromCodeCoverage]
    public class RoomResponse
    {
        public Guid Id { get; internal set; }
        public string Description { get; internal set; }
    }
}
