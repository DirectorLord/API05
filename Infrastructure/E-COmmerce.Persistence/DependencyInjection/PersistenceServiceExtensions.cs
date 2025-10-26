using E_COmmerce.Persistence.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using E_Commerce.Persistence.DBInitializers;
using E_Commerce.Persistence.Repositories;
using StackExchange.Redis;
using E_Commerce.Service.Abstraction;
using E_Commerce.Persistence.Services;


namespace E_Commerce.Persistence.DependencyInjection;

public static class PersistenceServiceExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services
        , IConfiguration configuration )
    {
        services.AddScoped<ICashService, CashService>();
        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddSingleton<IConnectionMultiplexer>(cfg =>
        {
            return ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection")!);
        });
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            var connection = configuration.GetConnectionString("SQLConnection");
            options.UseSqlServer(connection);
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDInitializer, DBInitializer>();
        return services;
    }
}
