﻿using Bookify.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Users;
public static class UserErrors
{
    public static readonly Error NotFound =
        new("User.NotFound", "The user with the specified identifier was not found");
}
