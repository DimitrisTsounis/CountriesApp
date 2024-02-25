using System.Net;

namespace CountriesApp.Api.Middleware;

public class ExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch(Exception e)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ErrorDetails details = new()
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = e.Source!,
                Title = "Server error",
                Detail = e.Message
            };

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(details);
        }
    }
}

internal class ErrorDetails
{
    public int Status { get; set; }
    public string Type { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Detail { get; set; } = default!;
}
