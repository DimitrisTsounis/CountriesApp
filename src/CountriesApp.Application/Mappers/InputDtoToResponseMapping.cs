using CountriesApp.Application.Models;
using CountriesApp.Domain.Entities;

namespace CountriesApp.Application.Mappers;

public static class InputDtoToResponseMapping
{
    public static List<CountryResponseDTO> MapToCountryResponseDTO(this List<CountriesExternalApiInputDTO> input)
    {
        var responseModel = new List<CountryResponseDTO>();

        foreach (var country in input)
        {
            responseModel.Add(new()
            {
                CommonName = country.Name.Common ?? string.Empty,
                Capital = country.Capital != null
                    ? string.Join(',', country.Capital)
                    : null,
                Borders = country.Borders != null
                    ? string.Join(',', country.Borders!)
                    : null
            });
        }

        return responseModel;
    }

    public static List<CountryResponseDTO> MapToCountryResponseDTO(this List<Country> input)
    {
        var responseModel = new List<CountryResponseDTO>();

        foreach(var country in input)
        {
            responseModel.Add(new()
            {
                CommonName = country.CommonName,
                Capital = country.Capital,
                Borders = country.Borders!
            });
        }

        return responseModel;
    }

    public static List<Country> MapToDbEntity(this List<CountriesExternalApiInputDTO> input)
    {
        var responseModel = new List<Country>();

        foreach (var country in input)
        {
            responseModel.Add(new()
            {
                CommonName = country.Name.Common ?? string.Empty,
                Capital = country.Capital != null
                    ? string.Join(',', country.Capital)
                    : null,
                Borders = country.Borders != null
                    ? string.Join(',', country.Borders!)
                    : null
            });
        }

        return responseModel;
    }
}
