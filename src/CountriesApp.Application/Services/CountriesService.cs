using CountriesApp.Application.Common.Interfaces;
using CountriesApp.Application.Mappers;
using CountriesApp.Application.Models;
using CountriesApp.Infrastructure.Repositories;
using System.Text.Json;

namespace CountriesApp.Application.Services;

public class CountriesService : ICountriesService
{
    private readonly ICountriesExternalApiClient _countriesExternalApiClient;
    private readonly ICountriesRepository _countriesRepository;

    public CountriesService(
        ICountriesExternalApiClient countriesExternalApiClient, 
        ICountriesRepository countriesRepository)
    {
        _countriesExternalApiClient = countriesExternalApiClient;
        _countriesRepository = countriesRepository;
    }

    public async Task<List<CountryResponseDTO>> GetCountries()
    {

        var countries = await _countriesRepository.GetCountriesAsync();

        if (countries == null || countries.Count == 0)
        {
            var externalCountries = await FetchCountriesFromExternalAPI();
            await _countriesRepository.AddCountriesAsync(externalCountries!.MapToDbEntity());

            return externalCountries!.MapToCountryResponseDTO();
        }

        return countries.MapToCountryResponseDTO();
    }

    private async Task<List<CountriesExternalApiInputDTO>?> FetchCountriesFromExternalAPI()
    {
        var response = await _countriesExternalApiClient.GetCountries();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        var countries = await JsonSerializer.DeserializeAsync<List<CountriesExternalApiInputDTO>>(response!, options);

        if (countries == null || countries.Count == 0)
            throw new ApplicationException("ExternalApi response-deserialization failure.");

        return countries;
    }
}
