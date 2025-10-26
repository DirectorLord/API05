
namespace E_Commerce.Persistence.Context.Configurations;

internal class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name)
               .HasColumnType("varchar")
               .HasMaxLength(100);

        builder.Property(p => p.PictureUrl)
               .HasColumnType("varchar")
               .HasMaxLength(100);

        builder.Property(p => p.Description)
               .HasColumnType("varchar")
               .HasMaxLength(100);

        builder.Property(p => p.Price)
               .HasColumnType("decimal(10,2)");

        builder.HasOne(p => p.ProductBrand).WithMany()
               .HasForeignKey(p => p.ProductBrandId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.ProductsType).WithMany()
               .HasForeignKey(p => p.ProductsTypeId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
