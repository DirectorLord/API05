using System.Linq.Expressions;

namespace E_Commerce.Service.Specifications;

internal sealed class ProductCountSpecification(ProductQueryParameters parameters) : BaseSpecification<Product>(CreateCriteria(parameters))
{
    private static Expression<Func<Product, bool>> CreateCriteria(ProductQueryParameters parameters)
    {
        return p => (!parameters.BrandId.HasValue || p.ProductBrandId == parameters.BrandId.Value) &&
        (!parameters.TypeId.HasValue || p.ProductsTypeId == parameters.TypeId.Value)
        && (string.IsNullOrWhiteSpace(parameters.Search) || p.Name.Contains(parameters.Search));
    }
}
