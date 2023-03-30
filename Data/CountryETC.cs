using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationKeysTest.Models;

namespace TranslationKeysTest.Data;

public class CountryETC : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Code).IsUnique();
        builder.Property(x => x.Code).HasColumnType("varchar(2)");

        builder.Property(x => x.Name).HasColumnType("jsonb");
    }
}