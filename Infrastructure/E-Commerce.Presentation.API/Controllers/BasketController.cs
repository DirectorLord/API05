using E_Commerce.Service.Abstraction;
using E_Commerce.Shared.DataTransferObjects.Basket;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce.Presentation.API.Controllers;

public class BasketController(IBasketService basketService)
    : APIBaseController
{
    #region Post
    [HttpPost]
    public async Task<ActionResult<CustomerBasketDTO>> Update(CustomerBasketDTO basketDTO)
    {
        return Ok(await basketService.CreateOrUpdateAsync(basketDTO));
    }
    #endregion
    #region Get

    [HttpGet]
    public async Task<ActionResult<CustomerBasketDTO>> Get(string id)
    {
        return Ok(await basketService.GetByIdAsync(id));
    }
    #endregion

    #region Delete
    [HttpDelete]
    public ActionResult Delete(string id)
    {
        basketService.DeletedAsync(id);
        return NoContent();
    } 
    #endregion
}
