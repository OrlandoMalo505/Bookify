using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Exceptions;
public sealed class ValidationError
{
    public string PropertyName { get; init; }
    public string ErrorMessage { get; init; }
}
