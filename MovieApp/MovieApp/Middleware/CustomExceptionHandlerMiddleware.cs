using System.Net;
using Application.Common.Exceptions;
using FluentValidation;

namespace MovieApp.Middleware;

public class CustomExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public CustomExceptionHandlerMiddleware(RequestDelegate next) =>
        _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = string.Empty;

        switch (exception)
        {
            case ValidationException validationException:
                code = HttpStatusCode.BadRequest;
                //   result = JsonSerializer.Serialize(validationException.Errors);

                break;
            case ForbiddenAccessException:
                code = HttpStatusCode.NotFound;

                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int) code;

        return context.Response.WriteAsync(result);
    }
}
