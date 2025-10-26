using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Middlewares;

public class GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next.Invoke(context);
        }catch (Exception ex)
        {
            logger.LogError("Something went wrong", ex.Message);

            var problem = new ProblemDetails
            {
                Title = "Error processing the Http request",
                Detail = ex.Message,
                Instance = context.Request.Path,
                Status = StatusCodes.Status500InternalServerError
            };
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}
public static class GlobalExceptionHandlerExtensions
{
    public static WebApplication UseCustomExceptionHandler(this WebApplication app)
    {
         app.UseMiddleware<GlobalExceptionHandler>();
        return app;
    }
}