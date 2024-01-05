using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Bookify.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Infrastructure.Repositories;
internal sealed class BookingRepository : Repository<Booking>, IBookingRepository
{
    private static readonly BookingStatus[] ActiveBookingStatuses =
        [BookingStatus.Reserved, BookingStatus.Confirmed, BookingStatus.Completed];
    public BookingRepository(ApplicationDbContext context) : base(context)
    {
    }

    public Task Get()
    {
        try
        {
            var x = _context.Set<Booking>().Include(b => b.ApartmentId).ToList();

        }
        catch (Exception)
        {

            throw;
        }

        return Task.CompletedTask;

    }

    public async Task<bool> IsOverlappingAsync(Apartment apartment, DateRange duration, CancellationToken cancellationToken = default)
    {

        return await _context
            .Set<Booking>()
            .AnyAsync(
            booking =>
            booking.ApartmentId == apartment.Id &&
            booking.Duration.Start <= duration.End &&
            booking.Duration.End >= duration.Start &&
            ActiveBookingStatuses.Contains(booking.Status),
            cancellationToken);
    }
}
