using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entity;

namespace MyApp.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Category> Categories { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

       
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("Genres");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.IsActive);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
            entity.HasMany<Guid>("_categories").WithOne(); // Assuming a shadow property for categories if not using another Entity
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Categories");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(10_000);
            entity.Property(e => e.IsActive);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
        });

        builder.ApplyConfiguration(new GenresCategoriesConfiguration());
    }
}
