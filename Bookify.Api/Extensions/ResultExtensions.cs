using Bookify.Domain.Abstractions;
using System.Runtime.CompilerServices;

namespace Bookify.Api.Extensions;

public static class ResultExtensions
{
    public static IResult ToProblemDetails(this Result result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException("Can't convert success result to problem");
        }

        return Results.Problem(
            statusCode: StatusCodes.Status400BadRequest,
            type: "Bad Request",
            title: "Bad Request",
            detail: "This is a bad request",
            extensions: new Dictionary<string, object?>
            {
                {"errors",  new[]{ result.Error} }
            });
    }
}
