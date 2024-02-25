namespace CountriesApp.Application.Models;

public record CountryResponseDTO
{
    public string CommonName { get; init; } = default!;
    public string? Capital { get; init; } = default!;
    public string? Borders { get; init; } = default!;
}
