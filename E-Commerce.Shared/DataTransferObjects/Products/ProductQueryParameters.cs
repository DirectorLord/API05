namespace E_Commerce.Shared.DataTransferObjects.Products;

public class ProductQueryParameters
{
    private const int MaxSizePage = 10;
    private const int DefaultPageSize = 5;
    public int? BrandId { get; set; }
    public int? TypeId { get; set; }
    public string? Search { get; set; }
    public ProductSortingOptions Sort { get; set; }
    private int pageSize = DefaultPageSize;
    public int PageSize
    {
        get => pageSize; 
        set => pageSize = value > MaxSizePage ? MaxSizePage : value < DefaultPageSize ? DefaultPageSize : value;
    }
    public int PageIndex { get; set; } = 1;

}
public enum ProductSortingOptions
{
    NameAsc = 1,
    NameDesc = 2,
    PriceAsc = 3,
    PriceDesc = 4,
}
 