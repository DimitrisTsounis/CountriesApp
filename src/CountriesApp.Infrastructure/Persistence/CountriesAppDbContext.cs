using CountriesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CountriesApp.Infrastructure.Persistence;

public class CountriesAppDbContext : DbContext
{
    public CountriesAppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Country> Countries { get; set; }
}
