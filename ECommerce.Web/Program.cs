using E_Commerce.Domain.Contracts;
using E_Commerce.Persistence.DependencyInjection;
using E_Commerce.Service.DependencyInjections;
namespace ECommerce.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddPersistenceServices(builder.Configuration);

            builder.Services.AddApplicationServices();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            var scope = app.Services.CreateScope();
            var initializer = scope.ServiceProvider.GetRequiredService<IDInitializer>();
            await initializer.InitializeAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
