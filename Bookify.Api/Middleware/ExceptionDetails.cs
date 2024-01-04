using Bookify.Domain.Abstractions;

namespace Bookify.Api.Middleware;

internal record ExceptionDetails(
    int Status,
    string Type,
    string Title,
    string Detail,
    IEnumerable<Error?> Errors);
