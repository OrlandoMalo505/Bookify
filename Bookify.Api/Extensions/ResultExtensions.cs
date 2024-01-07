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

    public static IResult ToOkDetails<T>(this Result<T> result)
    {
        if (result.IsFailure)
        {
            throw new InvalidOperationException("Can't convert failure result to success");
        }

        return Results.Problem(
            statusCode: StatusCodes.Status200OK,
            type: "Success",
            title: "200 OK",
            detail: "200 OK",
            extensions: new Dictionary<string, object?>
            {
                {"data",  new List<T>(){result.Value } }
            });
    }
}
