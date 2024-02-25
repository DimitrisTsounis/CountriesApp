namespace CountriesApp.Application.Common.Interfaces;

public interface ICountriesExternalApiClient
{
    public Task<Stream?> GetCountries();
}