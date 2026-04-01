using Bookly.Application.Common.Exceptions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Bookly.WebAPI.Middlewares;
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync ( HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BusinessException ex)
        {
            await HandleExceptionAsync(context, ex.Message, HttpStatusCode.BadRequest);
        }
        catch (NotFoundException ex)
        {
            await HandleExceptionAsync(context, ex.Message, HttpStatusCode.NotFound);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex.Message, HttpStatusCode.BadRequest);
        }
    }



    private static async Task HandleExceptionAsync(HttpContext context,string message,HttpStatusCode statusCode)
    {
    context.Response.ContentType="application/json";
        context.Response.StatusCode = (int)statusCode;
        var result = JsonSerializer.Serialize(new { error = message });
        await context.Response.WriteAsync(result);
    }
}
