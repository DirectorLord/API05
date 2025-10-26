using E_Commerce.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Handlers;

public class NotFoundExceptionHandler(ILogger<NotFoundExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception ex, CancellationToken cancellationToken)
    {
        if(ex is NotFoundException)
        {
            logger.LogWarning("NotFoundException: {Message}", ex.Message);
            var problem = new ProblemDetails
            {
                Title = "Resource not found",
                Detail = ex.Message,
                Instance = context.Request.Path,
                Status = StatusCodes.Status404NotFound
            };
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(problem, cancellationToken);
            return true;
        }
        return false;
    }
}
