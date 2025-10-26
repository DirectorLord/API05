using E_Commerce.Shared.DataTransferObjects;
using E_Commerce.Shared.DataTransferObjects.Products;

namespace E_Commerce.Service.Abstraction;

public interface IProductService
{
    Task<PaginatedResult<ProductResponse>> GetProductsAsync(ProductQueryParameters parameters ,CancellationToken cancellationToken = default);
    Task<ProductResponse?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<BrandResponse>> GetBrandAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<TypeResponse>> GetTypesAsync(CancellationToken cancellationToken = default);
}
