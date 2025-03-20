using System.Diagnostics.CodeAnalysis;
using Genesis.TechChallenge.Domain.Exceptions;

namespace Genesis.TechChallenge.WebAPI.Extensions;

[ExcludeFromCodeCoverage]
public static class LoggerExtensions
{
    public static void LogException(this ILogger logger, Exception exception, string path, string? requestId, string? traceId)
    {
        switch (exception)
        {
            case DomainException _:
            case ApplicationException _:
                logger.LogInformation(exception, "Handled exception while processing request {Path}, RequestId: {RequestId}, TraceId: {TraceId}",
                    path, requestId, traceId);
                break;
            
            default:
                logger.LogError(exception, "An error occurred while processing request {Path}, RequestId: {RequestId}, TraceId: {TraceId}",
                    path, requestId, traceId);
                break;
        }
    }
}