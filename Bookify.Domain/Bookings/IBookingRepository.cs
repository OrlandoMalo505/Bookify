using Bookify.Domain.Apartments;
using Bookify.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Bookings;
public interface IBookingRepository
{
    void Add(Booking booking);
    Task<bool> IsOverlappingAsync(Apartment apartment, DateRange duration, CancellationToken cancellationToken = default);
    Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
