using Bookify.Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Abstractions.Behaviours;
public class LoggingBeaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand
{
    private readonly ILogger<TRequest> _logger;

    public LoggingBeaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var name = request.GetType().Name;

        try
        {
            _logger.LogInformation($"Executing command {name}");

            var result = await next();

            _logger.LogInformation($"Command {name} processed successfully");

            return result;

        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Command {name} failed");
            throw;
        }
    }
}
