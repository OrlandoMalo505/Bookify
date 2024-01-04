using Bookify.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Exceptions;
public class ValidationException : Exception
{
    public ValidationException(IEnumerable<Error> errors)
    {
        Errors = errors;
    }
    public IEnumerable<Error> Errors { get; }
}
