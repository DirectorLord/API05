using Microsoft.AspNetCore.Mvc;
using E_Commerce.Presentation.API.Attributes;

namespace ECommerce.Web.Controllers;
[ApiController, Route("api/[Controller]")]
public class ProductsController : ControllerBase
{
    #region GetID
    [RedisCash]
    [HttpGet("Products/{id}")]
    public ActionResult Get(int id)
    {
        return Ok(new Product { Id = id });
    }
    #endregion

    #region GetAll
    [HttpGet("/Products")]
    public ActionResult GetAll()
    {
        return Ok(new Product { });
    }
    #endregion

    #region Post
    [HttpPost]
    public ActionResult Create(Product product)
    {
        return Created("Test", product);
    }
    #endregion

    #region Edit
    [HttpPut]
    public ActionResult Update(Product product)
    {
        return Ok(product);
    }
    #endregion

    #region Delete
    [HttpDelete]
    public ActionResult Delete(int id)
    {
        return NoContent();
    }
    #endregion
}
public class Product
{
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "Product";
}
