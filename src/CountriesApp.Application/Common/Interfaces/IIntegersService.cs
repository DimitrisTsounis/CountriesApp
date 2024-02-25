using CountriesApp.Application.Models;

namespace CountriesApp.Application.Common.Interfaces;

public interface IIntegersService
{
    Task<int> GetSecondLargest(RequestObj request);
}