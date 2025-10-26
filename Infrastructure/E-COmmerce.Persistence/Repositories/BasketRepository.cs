using E_Commerce.Domain.Entities.Basket;
using StackExchange.Redis;
using System.Text.Json;

namespace E_Commerce.Persistence.Repositories;

public class BasketRepository(IConnectionMultiplexer multiplexer) : IBasketRepository
{
    private readonly IDatabase _database = multiplexer.GetDatabase();
    public async Task<CustomerBasket> CreateOrUpdateAsync(CustomerBasket basket, TimeSpan? TTL = null)
    {
        var json = JsonSerializer.Serialize(basket);
        await _database.StringSetAsync(basket.Id, json, TTL ?? TimeSpan.FromDays(7));
        return (await GetAsync(basket.Id))!;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        return await _database.KeyDeleteAsync(id);
    }

    public async Task<CustomerBasket?> GetAsync(string id)
    {
        var json = await _database.StringGetAsync(id);

        if (json.IsNullOrEmpty) return null;

        return JsonSerializer.Deserialize<CustomerBasket>(json!);
    }
}
