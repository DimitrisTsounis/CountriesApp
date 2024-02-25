using CountriesApp.Application.Models;

namespace CountriesApp.Application.Common.Interfaces;

public interface ICountriesService
{
    public Task<List<CountryResponseDTO>> GetCountries();
}