namespace E_Commerce.Domain.Entities.Products;

public class ProductsType : Entity<int>
{
    public string Name { get; set; } = default!;
}
