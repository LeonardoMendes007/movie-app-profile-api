using FluentValidation.Results;
using MovieApp.ProfileApi.API.Response;
using MovieApp.ProfileApi.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace MovieApp.ProfileApi.API.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, "An error occurred.");

        var response = exception switch
        {
            UserAlreadyExistsException _ => new ResponseBase(HttpStatusCode.Conflict, exception.Message),
            ResourceNotFoundException _ => new ResponseBase(HttpStatusCode.NotFound, exception.Message),
            _ => new ResponseBase(HttpStatusCode.InternalServerError, "Internal server error. Please retry later.")
        } ;

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)response.StatusCode;
        await context.Response.WriteAsJsonAsync(response);
    }
}
