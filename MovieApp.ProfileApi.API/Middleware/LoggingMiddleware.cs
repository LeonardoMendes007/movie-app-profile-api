using Azure;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieApp.ProfileApi.API.Response;
using MovieApp.ProfileApi.Domain.Exceptions;
using System.Net;

namespace MovieApp.ProfileApi.API.Middleware;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation($"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}] Received request: {context.Request.Method} {context.Request.Path}");

        await _next(context);

        _logger.LogInformation($"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}] Finished processing request: {context.Request.Method} {context.Request.Path} => {context.Response.StatusCode}");
    }
}
