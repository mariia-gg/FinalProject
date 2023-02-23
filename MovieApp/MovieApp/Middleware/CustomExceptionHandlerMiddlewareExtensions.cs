namespace MovieApp.Middleware;

public static class CustomExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(
        this
            IApplicationBuilder builder
    ) =>
        builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
}