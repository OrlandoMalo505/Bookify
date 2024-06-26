﻿using Bookify.Application.Abstractions.Behaviours;
using Bookify.Domain.Bookings;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            config.AddOpenBehavior(typeof(LoggingBeaviour<,>));

            config.AddOpenBehavior(typeof(ValidationBehaviour<,>));

            //config.AddBehavior(typeof(IRequestPreProcessor<>), typeof(ValidationBehaviour<>));
        });

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddTransient<PricingService>();

        services.AddSingleton(TimeProvider.System);

        return services;
    }
}
