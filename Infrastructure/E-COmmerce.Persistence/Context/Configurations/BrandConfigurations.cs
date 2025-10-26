using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Persistence.Context.Configurations;

internal class BrandConfigurations : IEntityTypeConfiguration<ProductBrand>
{
    public void Configure(EntityTypeBuilder<ProductBrand> builder)
    {
        builder.Property(pb => pb.Name)
               .HasColumnType("varchar")
               .HasMaxLength(100);
    }
}
