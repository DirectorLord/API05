using E_Commerce.Shared.DataTransferObjects.Basket;

namespace E_Commerce.Service.Abstraction;

public interface IBasketService
{
    Task<CustomerBasketDTO> CreateOrUpdateAsync(CustomerBasketDTO basketDto);
    Task<CustomerBasketDTO> GetByIdAsync(string id);
    Task DeletedAsync(string id);
}
