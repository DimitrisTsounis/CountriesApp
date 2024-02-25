using System.Text.Json.Serialization;

namespace CountriesApp.Application.Models;

public record NameExternalApiInputDTO
{
    [JsonPropertyName("common")]
    public string Common { get; init; } = default!;
}
