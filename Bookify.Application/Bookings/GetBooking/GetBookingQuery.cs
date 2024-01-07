using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Bookings.GetBooking;
public record GetBookingQuery(Guid id) : IQuery<Booking>;
