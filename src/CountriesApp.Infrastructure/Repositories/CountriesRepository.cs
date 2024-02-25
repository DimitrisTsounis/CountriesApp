using CountriesApp.Domain.Entities;
using CountriesApp.Infrastructure.Persistence;

namespace CountriesApp.Infrastructure.Repositories;

public class CountriesRepository : ICountriesRepository
{
    private readonly CountriesAppDbContext _context;

    public CountriesRepository(CountriesAppDbContext context)
    {
        _context = context;
    }

    public async Task AddCountriesAsync(List<Country> countries)
    {
        await _context.Countries.AddRangeAsync(countries);
        
        await _context.SaveChangesAsync();
    }

    public async Task<List<Country>> GetCountriesAsync()
    {
        return await _context.Countries.ToListAsync();
    }
}
