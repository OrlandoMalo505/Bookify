using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Bookings.GetBooking;
internal sealed class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, Booking>
{
    public async Task<Result<Booking>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        return new Booking();
    }
}
