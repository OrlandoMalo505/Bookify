using Bookify.Api.Controllers.Bookings;
using Bookify.Application.Apartments;
using Bookify.Application.Bookings.ReserveBooking;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Api.Controllers.Apartments;
[ApiController]
[Route("api/[controller]")]
public class ApartmentsController : ControllerBase
{
    private readonly ISender _sender;

    public ApartmentsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IResult> CreateApartment()
    {
        var command = new CreateApartmentCommand();

        return Results.Ok((await _sender.Send(command)).Value);
    }
}
