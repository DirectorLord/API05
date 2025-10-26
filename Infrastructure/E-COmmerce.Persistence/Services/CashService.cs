using E_Commerce.Service.Abstraction;
using StackExchange.Redis;
using System.Text.Json;

namespace E_Commerce.Persistence.Services;

internal class CashService(IConnectionMultiplexer multiplexer)
    : ICashService
{
    private readonly IDatabase _database = multiplexer.GetDatabase();
    public async Task<string?> GetAsync(string key)
    {
        return await _database.StringGetAsync(key);
    }

    public async Task SetAsync(string key, object value, TimeSpan TTL)
    {
        var json = JsonSerializer.Serialize(value);
        await _database.StringSetAsync(key, json, TTL);
    }
}
