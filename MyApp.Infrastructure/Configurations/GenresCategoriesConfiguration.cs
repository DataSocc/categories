using MyApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyApp.Infrastructure.Configurations;
internal class GenresCategoriesConfiguration
    : IEntityTypeConfiguration<GenresCategories>
{
    public void Configure(EntityTypeBuilder<GenresCategories> builder)
        => builder.HasKey(relation => new
        {
            relation.CategoryId,
            relation.GenreId
        });
}