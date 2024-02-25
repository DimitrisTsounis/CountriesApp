using CountriesApp.Application.Common.Interfaces;
using CountriesApp.Infrastructure.ExternalApiClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CountriesApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICountriesExternalApiClient, CountriesExternalApiClient>();
        services.AddHttpClient(
            name: "countriesExternalApi",
            client =>
            {
                client.BaseAddress = new Uri(configuration["CountriesExternalApiURL"]!);
            });

        return services;
    }
}
