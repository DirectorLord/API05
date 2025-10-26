using E_Commerce.Domain.Entities.Basket;
using E_Commerce.Shared.DataTransferObjects.Basket;

namespace E_Commerce.Service.Services;

public class BasketService(IBasketRepository basketRepository, IMapper mapper) : IBasketService
{
    public async Task<CustomerBasketDTO> CreateOrUpdateAsync(CustomerBasketDTO basketDto)
    {
        var basket = mapper.Map<CustomerBasket>(basketDto);
        var updatedBasket = await basketRepository.CreateOrUpdateAsync(basket);
        return mapper.Map<CustomerBasketDTO>(updatedBasket);
    }

    public Task DeletedAsync(string id)
    => basketRepository.DeleteAsync(id);

    public Task<CustomerBasketDTO> GetByIdAsync(string id)
    {
        var basket = basketRepository.GetAsync(id);
        return mapper.Map<CustomerBasketDTO>(basket);
    }
}
