using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entity;
using MyApp.Infrastructure.Configurations;

namespace MyApp.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Category> Categories { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new GenreConfiguration());

        builder.ApplyConfiguration(new GenresCategoriesConfiguration());

    }

}
