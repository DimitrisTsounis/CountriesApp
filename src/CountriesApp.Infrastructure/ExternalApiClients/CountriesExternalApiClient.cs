namespace CountriesApp.Infrastructure.ExternalApiClients;

public class CountriesExternalApiClient : ICountriesExternalApiClient
{
    private const string CountriesApiEndpoint = "all";
    private readonly IHttpClientFactory _httpClientFactory;

    public CountriesExternalApiClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Stream?> GetCountries()
    {
        var client = _httpClientFactory.CreateClient(name: "countriesExternalApi");

        var response = await client.GetAsync(requestUri: CountriesApiEndpoint);

        if (!response.IsSuccessStatusCode)
            throw new ApplicationException("Countries API error");

        var result = await response.Content.ReadAsStreamAsync();

        return result;
    }
}
