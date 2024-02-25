using CountriesApp.Infrastructure.ExternalApiClients;
using CountriesApp.Infrastructure.Persistence;
using CountriesApp.Infrastructure.Repositories;

namespace CountriesApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CountriesAppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("defaultConnection")));
        
        services.AddScoped<CountriesRepository>();
        services.AddScoped<ICountriesRepository, CacheCountriesRepository>();
        services.AddScoped<ICountriesExternalApiClient, CountriesExternalApiClient>();
        
        services.AddHttpClient(
            name: "countriesExternalApi",
            client =>
            {
                client.BaseAddress = new Uri(configuration["CountriesExternalApiURL"]!);
            });

        services.AddMemoryCache();

        return services;
    }
}
