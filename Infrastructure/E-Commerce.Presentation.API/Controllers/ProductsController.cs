using E_Commerce.Service.Abstraction;
using E_Commerce.Shared.DataTransferObjects;
using E_Commerce.Shared.DataTransferObjects.Products;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.API.Controllers;

public  class ProductsController (IProductService service)
    : APIBaseController
{
    #region Get
    #region GetAll
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<ProductResponse>>> GetProducts([FromQuery]ProductQueryParameters parameters ,CancellationToken cancellationToken = default)
    {
        var response = await service.GetProductsAsync(parameters,cancellationToken);
        return Ok(response);
    }
    #endregion

    #region GetById
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> Get(int id, CancellationToken cancellationToken = default)
    {
        var response = await service.GetByIdAsync(id, cancellationToken);
        return Ok(response);
    }
    #endregion

    #region GetBrand
    [HttpGet("Brands")]
    public async Task<ActionResult<IEnumerable<BrandResponse>>> GetBrands(CancellationToken cancellationToken = default)
    {
        var response = await service.GetBrandAsync(cancellationToken);
        return Ok(response);
    }
    #endregion

    #region GetTypes
    [HttpGet("Types")]
    public async Task<ActionResult<IEnumerable<TypeResponse>>> GetTypes(CancellationToken cancellationToken = default)
    {
        var response = await service.GetTypesAsync(cancellationToken);
        return Ok(response);
    }
    #endregion 
    #endregion


}
