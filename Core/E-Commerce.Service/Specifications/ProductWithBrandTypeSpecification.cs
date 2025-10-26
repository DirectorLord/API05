using System.Linq.Expressions;

namespace E_Commerce.Service.Specifications;

internal class ProductWithBrandTypeSpecification : BaseSpecification<Product>
{
    public ProductWithBrandTypeSpecification(ProductQueryParameters parameters)
        : base(CreateCriteria(parameters))
    {
        AddInclude(p => p.ProductsType);
        AddInclude(p => p.ProductBrand);
        Sort(parameters);
    }

    private void Sort(ProductQueryParameters parameters)
    {
        switch (parameters.Sort)
        {
            case ProductSortingOptions.NameAsc:
                AddOrderBy(p => p.Name);
                break;
            case ProductSortingOptions.NameDesc:
                AddOrderByDesc(p => p.Name);
                break;
            case ProductSortingOptions.PriceAsc:
                AddOrderBy(p => p.Price);
                break;
            case ProductSortingOptions.PriceDesc:
                AddOrderByDesc(p => p.Name);
                break;
            default:
                AddOrderBy(p => p.Name);
                break;
        }
    }

    private static Expression<Func<Product, bool>> CreateCriteria(ProductQueryParameters parameters)
    {
        return p => (!parameters.BrandId.HasValue || p.ProductBrandId == parameters.BrandId.Value) &&
        (!parameters.TypeId.HasValue || p.ProductsTypeId == parameters.TypeId.Value)
        && (string.IsNullOrWhiteSpace(parameters.Search) ||p.Name.Contains(parameters.Search));
    }

    public ProductWithBrandTypeSpecification(int id)
        : base(p => p.Id == id)
    {
        AddInclude(p => p.ProductsType);
        AddInclude(p => p.ProductBrand);
    }
}
