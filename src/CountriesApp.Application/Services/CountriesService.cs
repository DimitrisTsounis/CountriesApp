using CountriesApp.Application.Common.Interfaces;
using CountriesApp.Application.Mappers;
using CountriesApp.Application.Models;
using System.Text.Json;

namespace CountriesApp.Application.Services;

public class CountriesService : ICountriesService
{
    private readonly ICountriesExternalApiClient _countriesExternalApiClient;

    public CountriesService(ICountriesExternalApiClient countriesExternalApiClient)
    {
        _countriesExternalApiClient = countriesExternalApiClient;
    }

    public async Task<List<CountryResponseDTO>> GetCountries()
    {
        var response = await _countriesExternalApiClient.GetCountries();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        var countries = await JsonSerializer.DeserializeAsync<List<CountriesExternalApiInputDTO>>(response!, options);

        if (countries == null || countries.Count == 0)
            throw new ApplicationException();

        return countries.Select(it => it.MapToCountryResponseDTO()).ToList();
    }
}
