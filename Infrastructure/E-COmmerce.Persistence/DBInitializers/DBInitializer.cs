using System.Text.Json;

namespace E_Commerce.Persistence.DBInitializers;

internal class DBInitializer(ApplicationDbContext dbContext) : IDInitializer
{
    public async Task InitializeAsync()
    {
        try
        {
            if ((await dbContext.Database.GetPendingMigrationsAsync()).Any())
                await dbContext.Database.MigrateAsync();
            if (!await dbContext.Products.AnyAsync())
            {
                var BrandData = await File.ReadAllTextAsync(
                    "@Infrastructure/E-COmmerce.Persistence/DBInitializers/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandData);
                if (brands != null && brands.Any())
                {
                    dbContext.ProductBrands.AddRange(brands);
                }
                await dbContext.SaveChangesAsync();
            }
            if (!dbContext.ProductsTypes.Any())
            {
                var TypeData = await File.ReadAllTextAsync(
                    "@Infrastructure/E-COmmerce.Persistence/DBInitializers/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductsType>>(TypeData);
                if (types != null && types.Any())
                {
                    dbContext.ProductsTypes.AddRange(types);
                }
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during database initialization: {ex.Message}");
        }
    }
}
