using E_Commerce.Service.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Middlewares;

public class GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next.Invoke(context);
            await HandleNotFoundEndPoint(context);
        }
        catch (Exception ex)
        {
            logger.LogError("Something went wrong", ex.Message);

            var problem = new ProblemDetails
            {
                Title = "Error processing the Http request",
                Detail = ex.Message,
                Instance = context.Request.Path,
                Status = ex switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                },
            };
            context.Response.StatusCode = problem.Status.Value;

            await context.Response.WriteAsJsonAsync(problem);
        }
    }

    private static async Task HandleNotFoundEndPoint(HttpContext context)
    {
        if (context.Response.StatusCode == StatusCodes.Status404NotFound)
        {
            var problem = new ProblemDetails
            {
                Title = "Resource not found",
                Detail = $"The requested resource '{context.Request.Path}' was not found.",
                Instance = context.Request.Path,
                Status = StatusCodes.Status404NotFound
            };
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