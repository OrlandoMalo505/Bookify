using Bookify.Application.Bookings.ReserveBooking;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;

namespace Bookify.Api.Controllers.Bookings;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly ISender _sender;

    public BookingsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public Task<IResult> GetBooking(Guid id, CancellationToken cancellationToken)
    {
        return (Task<IResult>)Results.Ok();
    }


    [HttpPost]
    public async Task<IResult> ReserveBooking(
        ReserveBookingRequest request,
        CancellationToken cancellationToken)
    {
        var command = new ReserveBookingCommand(request.ApartmentId, request.UserId, request.StartDate, request.EndDate);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result.Error);
        }

        return Results.CreatedAtRoute(nameof(GetBooking), new { id = result.Value }, result.Value);
    }
}
