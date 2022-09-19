using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Commands
{
    public interface ICommand<TCommand, TResult>
    {
        public Task<TResult> ExecuteAsync(TCommand command);
    }
}
