using Microsoft.AspNetCore.Mvc;
using MovieApp.ProfileApi.API.Response;
using MovieApp.ProfileApi.Application.Exceptions;
using MovieApp.ProfileApi.Domain.Exceptions;
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
        catch (ValidationException ex)
        {
            _logger.LogWarning("Validation error occurred");

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "ValidationFailure",
                Title = "Validation error",
                Detail = "One or more validation errors has occurred"
            };

            if (ex.Errors is not null)
            {
                problemDetails.Extensions["errors"] = ex.Errors;
            }

            await WriteResponseAsync<ProblemDetails>(context, problemDetails, HttpStatusCode.BadRequest);
        }
        catch (ResourceNotFoundException ex)
        {
            _logger.LogWarning("Resource not found");

            var response = ResponseBase.ResponseBaseFactory(HttpStatusCode.NotFound, ex.Message);

            await WriteResponseAsync<ResponseBase>(context, response, HttpStatusCode.NotFound);

        }
        catch (ProfileAlreadyExistsException ex)
        {
            _logger.LogWarning("Profile already exists");

            var response = ResponseBase.ResponseBaseFactory(HttpStatusCode.Conflict, ex.Message);

            await WriteResponseAsync<ResponseBase>(context, response, HttpStatusCode.Conflict);
        }
        catch (MovieAlreadyExistsFavoriteException ex)
        {
            _logger.LogWarning("Movie already exists in favorites");

            var response = ResponseBase.ResponseBaseFactory(HttpStatusCode.Conflict, ex.Message);

            await WriteResponseAsync<ResponseBase>(context, response, HttpStatusCode.Conflict);
        }
        catch (RatingAlreadyExistsForMovieException ex)
        {
            _logger.LogWarning("Rating already exists for movie");

            var response = ResponseBase.ResponseBaseFactory(HttpStatusCode.Conflict, ex.Message);

            await WriteResponseAsync<ResponseBase>(context, response, HttpStatusCode.Conflict);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred");

            var response = ResponseBase.ResponseBaseFactory(HttpStatusCode.InternalServerError, "Internal server error. Please retry later.");

            await WriteResponseAsync<ResponseBase>(context, response, HttpStatusCode.InternalServerError);
        }
    }

    public async Task WriteResponseAsync<T>(HttpContext context, T response, HttpStatusCode httpStatusCode)
    {

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)httpStatusCode;
        await context.Response.WriteAsJsonAsync(response);
    }
}
