using MyApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyApp.Infrastructure.Configurations;
internal class GenresCategoriesConfiguration
    : IEntityTypeConfiguration<GenresCategories>
{
    public void Configure(EntityTypeBuilder<GenresCategories> builder)
    {
        builder.HasKey(relation => new
        {
            relation.CategoryId,
            relation.GenreId
        });

        // Configuração para exclusão em cascata no relacionamento com Genre
        builder.HasOne(relation => relation.Genre)
               .WithMany() // Assuma que Genre tem uma coleção de GenresCategories, se existir
               .HasForeignKey(relation => relation.GenreId)
               .OnDelete(DeleteBehavior.Cascade); // Exclusão em cascata

        // Configuração para exclusão em cascata no relacionamento com Category
        builder.HasOne(relation => relation.Category)
               .WithMany() // Assuma que Category tem uma coleção de GenresCategories, se existir
               .HasForeignKey(relation => relation.CategoryId)
               .OnDelete(DeleteBehavior.Cascade); // Exclusão em cascata
    }
}