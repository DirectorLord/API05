using E_Commerce.Domain.Entities.Products;
using System.Reflection;

namespace E_COmmerce.Persistence.Context;

internal class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductsType> ProductsTypes { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
