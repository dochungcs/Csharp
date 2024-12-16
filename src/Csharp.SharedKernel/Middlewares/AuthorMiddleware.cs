using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Csharp.SharedKernel.Middlewares;

public class AuthorMiddleware(RequestDelegate next, ILogger<AuthorMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.Headers.Add("author", "Do Chi Hung");
        context.Response.Headers.Add("facebook", "https://www.facebook.com/");
        context.Response.Headers.Add("email", "dochihungcs@gmail.com");
        context.Response.Headers.Add("contact", "0976580418");
        
        logger.LogInformation("Do Chi Hung - dochihungcs@gmail.com - 0976580418");

        await next(context);
    }

}

public static class AuthorMiddlewareMiddlewareExtension
{
    public static IApplicationBuilder UseCoreAuthor(this IApplicationBuilder app)
    {
        return app.UseMiddleware<AuthorMiddleware>();
    }
}
