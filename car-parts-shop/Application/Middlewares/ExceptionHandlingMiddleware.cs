using Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Application.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            await HandleExceptionAsync(context, e);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var statusCode = GetStatusCode(exception);
        bool isValidationException = exception is ValidationException;

        Dictionary<string, object> response = new()
        {
            { "title", GetTitle(exception) },
            { "status", statusCode },
            { "message", isValidationException ? GetErrors(exception) : exception.Message }
        };

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static int GetStatusCode(Exception exception) =>
        exception switch
        {
            ExceptionBase exceptionBase => (int)exceptionBase.StatusCode, 
            ValidationException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };

    private static string GetTitle(Exception exception) =>
        exception switch
        {
            ExceptionBase exceptionBase => exceptionBase.MessageHeader,
            ValidationException => "Validation error", 
            _ => "Server Error"
        };

    private static IReadOnlyDictionary<string, List<string>> GetErrors(Exception exception)
    {
        Dictionary<string, List<string>> errors = new();

        if (exception is ValidationException validationException)
        {
            validationException.Errors
                .GroupBy(e => e.PropertyName)
                .SelectMany(e => e)
                .ToList();

            foreach (var error in validationException.Errors)
            {
                if (errors.ContainsKey(error.PropertyName) == false)
                {
                    errors[error.PropertyName] = new List<string>();
                }

                errors[error.PropertyName].Add(error.ErrorMessage);
            }
        }

        return errors;
    }
}