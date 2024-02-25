using CountriesApp.Application.Models;

namespace CountriesApp.Application.Mappers;

public static class InputDtoToResponseMapping
{
    public static CountryResponseDTO MapToCountryResponseDTO(this CountriesExternalApiInputDTO input)
    {
        return new()
        {
            CommonName = input.Name.Common,
            Capital = input.Capital,
            Borders = input.Borders!
        };
    }
}
