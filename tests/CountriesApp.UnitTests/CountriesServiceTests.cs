using CountriesApp.Application.Common.Interfaces;
using CountriesApp.Application.Mappers;
using CountriesApp.Application.Models;
using CountriesApp.Application.Services;
using CountriesApp.Domain.Entities;
using CountriesApp.Infrastructure.Repositories;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System.Text.Json;

namespace CountriesApp.UnitTests;

public class CountriesServiceTests
{
    [Fact]
    public async Task GetCountriesAsync_ReturnsCountriesFromCache_WhenCacheObjectExist()
    {
        // Arrange
        var cachedCountries = new List<Country>
        {
            new() { Id = 1, CommonName = "Country1", Capital = "Capital1", Borders = "border1" },
            new() { Id = 2, CommonName = "Country2", Capital = "Capital2", Borders = "border2" }
        };

        var repository = Substitute.For<ICountriesRepository>();
        repository.GetCountriesAsync().Returns(cachedCountries);

        var externalClient = Substitute.For<ICountriesExternalApiClient>();
        var countryService = new CountriesService(externalClient, repository);

        // Act
        var result = await countryService.GetCountries();

        // Assert
        result.Should().BeEquivalentTo(cachedCountries.MapToCountryResponseDTO());
        await repository.DidNotReceive().AddCountriesAsync(Arg.Any<List<Country>>());
    }

    [Fact]
    public async Task GetCountriesAsync_ReturnsCountriesFromExternalAPIService_WhenNoDataInRepository()
    {
        // Arrange
        var externalCountries = new List<CountriesExternalApiInputDTO>
        {
            new()
            {
                Name = new NameExternalApiInputDTO() { Common = "Country1" },
                Capital =  new List<string> { "Capital 1" },
                Borders = new List<string> { "Border 1" }
            }
        };

        var repository = Substitute.For<ICountriesRepository>();
        repository.GetCountriesAsync().Returns(new List<Country>());

        var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(JsonSerializer.Serialize(externalCountries)));
        
        var externalApiClient = Substitute.For<ICountriesExternalApiClient>();
        externalApiClient.GetCountries().Returns(stream);

        var service = new CountriesService(externalApiClient, repository);

        // Act
        var result = await service.GetCountries();

        // Assert
        result.Should().BeEquivalentTo(externalCountries.MapToCountryResponseDTO());
        await repository.Received().AddCountriesAsync(Arg.Any<List<Country>>());
    }

    [Fact]
    public async Task GetCountries_ThrowsException_WhenExternalAPIFails()
    {
        // Arrange
        var countriesRepository = Substitute.For<ICountriesRepository>();
        countriesRepository.GetCountriesAsync().Returns(new List<Country>());

        var externalApiClient = Substitute.For<ICountriesExternalApiClient>();
        externalApiClient.GetCountries().Throws(new HttpRequestException("External API error"));

        var service = new CountriesService(externalApiClient, countriesRepository);

        // Act
        Task act () => service.GetCountries();

        //Assert
        await Assert.ThrowsAsync<HttpRequestException>(act);
        await countriesRepository.DidNotReceive().AddCountriesAsync(Arg.Any<List<Country>>());
    }
}
