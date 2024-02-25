namespace CountriesApp.Domain.Entities;

public class Country
{
    public int Id { get; set; }
    public string CommonName { get; set; } = default!;
    public string? Capital { get; set; } = default!;
    public string? Borders { get; set; } = default!;
}
