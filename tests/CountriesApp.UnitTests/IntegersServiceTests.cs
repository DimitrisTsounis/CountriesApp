using CountriesAPI.Validators;
using CountriesApp.Application.Models;
using CountriesApp.Application.Services;
using FluentAssertions;
using FluentValidation;

namespace CountriesApp.UnitTests;

public class IntegersServiceTests
{
    [Fact]
    public async Task GetSecondLargest_ShouldReturnSecondLargest_WhenRequestIsValid()
    {
        // Arrange
        var request = new RequestObj
        {
            RequestArrayObj = new[] { 1, 3, 2, 4, 5 }
        };

        var validator = new RequestObjValidator();
        var service = new IntegersService(validator);

        // Act
        var result = await service.GetSecondLargest(request);

        // Assert
        result.Should().Be(4);
    }

    [Fact]
    public async Task GetSecondLargest_ShouldReturnSecondLargest_WhenRequestContainsDuplicates()
    {
        // Arrange
        var request = new RequestObj
        {
            RequestArrayObj = new[] { 1, 1, 1, 2, 2 }
        };

        var validator = new RequestObjValidator();
        var service = new IntegersService(validator);

        // Act
        var result = await service.GetSecondLargest(request);

        // Assert
        result.Should().Be(1);
    }

    [Fact]
    public async Task GetSecondLargest_ShouldReturnSuccessfully_WhenOnlyOneUniqueElementExists()
    {
        // Arrange
        var request = new RequestObj
        {
            RequestArrayObj = new[] { 1, 1, 1, 1, 1 }
        };

        var validator = new RequestObjValidator();
        var service = new IntegersService(validator);

        // Act
        var result = await service.GetSecondLargest(request);

        // Assert
        result.Should().Be(1);
    }

    [Fact]
    public async Task GetSecondLargest_ShouldThrowValidationException_WhenArrayIsEmpty()
    {
        // Arrange
        var request = new RequestObj
        {
            RequestArrayObj = Array.Empty<int>()
        };

        var validator = new RequestObjValidator();
        var service = new IntegersService(validator);

        // Act
        Task act() => service.GetSecondLargest(request);

        //Assert
        await Assert.ThrowsAsync<ValidationException>(act);
    }
}
