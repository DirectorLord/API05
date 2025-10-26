using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Persistence.Context.Configurations;

internal class TypeConfigurations : IEntityTypeConfiguration<ProductsType>
{
    public void Configure(EntityTypeBuilder<ProductsType> builder)
    {
        builder.Property(pt => pt.Name)
               .HasColumnType("varchar")
               .HasMaxLength(100);
    }
}
