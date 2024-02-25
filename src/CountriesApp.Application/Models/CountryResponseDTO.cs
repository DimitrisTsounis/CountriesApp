namespace CountriesApp.Application.Models;

public record CountryResponseDTO
{
    public string CommonName { get; init; } = default!;
    public IReadOnlyList<string> Capital { get; init; } = new List<string>();
    public IReadOnlyList<string> Borders { get; init; } = new List<string>();
}
