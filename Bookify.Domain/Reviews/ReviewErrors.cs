using Bookify.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Reviews;
public static class ReviewErrors
{
    public static readonly Error NotEligible = new("Review.NotEligible", "You cannot review this booking yet");
}

