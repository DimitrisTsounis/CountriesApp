using CountriesApp.Domain.Entities;

namespace CountriesApp.Infrastructure.Repositories;

public interface ICountriesRepository
{
    public Task AddCountriesAsync(List<Country> countries);
    public Task<List<Country>> GetCountriesAsync();
}