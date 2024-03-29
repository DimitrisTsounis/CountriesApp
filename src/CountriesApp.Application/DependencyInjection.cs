﻿using CountriesApp.Application.Common.Interfaces;
using CountriesApp.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CountriesApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>();
        services.AddScoped<IIntegersService, IntegersService>();
        services.AddScoped<ICountriesService, CountriesService>();

        return services;
    }
}
