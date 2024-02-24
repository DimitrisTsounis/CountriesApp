using CountriesApp.Application.Contracts;

namespace CountriesApp.Application.Services;

public interface IIntegersService
{
    Task<int> GetSecondLargest(RequestObj request);
}