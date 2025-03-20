using System.Diagnostics.CodeAnalysis;
using System.Net;
using Genesis.TechChallenge.Domain.Exceptions;
using Genesis.TechChallenge.WebAPI.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace Genesis.TechChallenge.WebAPI.Middlewares;

[ExcludeFromCodeCoverage]
public class GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (OperationCanceledException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
            logger.LogWarning("Request cancelled by client: {Path}", context.Request.Path);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = (int)HttpStatusCode.InternalServerError;
        var title = "An unexpected error occurred.";
        var detail = GetInnermostExceptionMessage(exception);

        switch (exception)
        {
            case DomainException:
                statusCode = (int)HttpStatusCode.BadRequest;
                title = "A domain validation error occurred.";
                break;
            
            case ApplicationException:
                statusCode = (int)HttpStatusCode.BadRequest;
                title = "An application error occurred.";
                break;
        }

        var requestId = context.TraceIdentifier;
        var traceId = context.Features.Get<IHttpActivityFeature>()?.Activity?.Id;

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = detail,
            Instance = context.Request.Path.ToString(),
            Extensions = new Dictionary<string, object?>
            {
                { "requestId", requestId },
                { "traceId", traceId },
                { "timestamp", DateTime.UtcNow }
            }
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        logger.LogException(exception, context.Request.Path, requestId, traceId);

        await context.Response.WriteAsJsonAsync(problemDetails);
    }
    
    private static string GetInnermostExceptionMessage(Exception ex)
    {
        while (ex.InnerException != null)
            ex = ex.InnerException;

        return ex.Message;
    }
}