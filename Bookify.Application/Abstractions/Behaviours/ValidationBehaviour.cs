using Bookify.Application.Abstractions.Messaging;
using Bookify.Application.Exceptions;
using FluentValidation;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Abstractions.Behaviours;
public class ValidationBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : IBaseCommand
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationErrors = _validators
                .Select(v => v.Validate(context))
                .Where(v => v.Errors.Any())
                .SelectMany(v => v.Errors)
                .Select(v => new ValidationError
                {
                    PropertyName = v.PropertyName,
                    ErrorMessage = v.ErrorMessage
                })
                .ToList();

            if (validationErrors.Any())
            {
                throw new Exceptions.ValidationException(validationErrors);
            }
            else
            {
                return Task.CompletedTask;
            }
        }

        return Task.CompletedTask;
    }
}
