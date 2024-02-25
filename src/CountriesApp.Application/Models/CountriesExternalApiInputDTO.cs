using System.Text.Json.Serialization;

namespace CountriesApp.Application.Models;

public record CountriesExternalApiInputDTO
{
    [JsonPropertyName("name")]
    public NameExternalApiInputDTO Name { get; init; } = default!;

    [JsonPropertyName("capital")]
    public List<string> Capital { get; init; } = default!;

    [JsonPropertyName("borders")]
    public List<string>? Borders { get; init; }

}
