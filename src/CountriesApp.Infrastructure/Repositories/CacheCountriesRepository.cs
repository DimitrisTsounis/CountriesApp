using CountriesApp.Domain.Entities;

namespace CountriesApp.Infrastructure.Repositories;

public class CacheCountriesRepository : ICountriesRepository
{
    private const string CacheKey = "Countries";
    
    private readonly IMemoryCache _memoryCache;
    private readonly CountriesRepository _decoratedRepository;

    public CacheCountriesRepository(IMemoryCache memoryCache, CountriesRepository countriesRepository)
    {
        _memoryCache = memoryCache;
        _decoratedRepository = countriesRepository;
    }

    public async Task<List<Country>> GetCountriesAsync()
    {
        if (!_memoryCache.TryGetValue(CacheKey, out List<Country>? countries))
        {
            countries = await _decoratedRepository.GetCountriesAsync();

            if (countries.Count > 0)
                _memoryCache.Set("Countries", countries, TimeSpan.FromMinutes(10));
        }

        return countries ?? [];
    }

    public async Task AddCountriesAsync(List<Country> countries)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
        };

        _memoryCache.Set(CacheKey, countries, cacheEntryOptions);

        await _decoratedRepository.AddCountriesAsync(countries);
    }
}
