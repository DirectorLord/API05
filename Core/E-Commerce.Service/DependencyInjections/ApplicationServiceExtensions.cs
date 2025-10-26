using E_Commerce.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace E_Commerce.Service.DependencyInjections;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBasketService, BasketService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
