using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace Genesis.TechChallenge.Infrastructure.Logging;

/// <summary>
/// Serilog Module
/// </summary>
[ExcludeFromCodeCoverage]
public static class SerilogModule
{
    /// <summary>
    /// Add Serilog Module
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public static IServiceCollection AddSerilogModule(this IServiceCollection services, IConfiguration configuration)
    {
        var elasticUrl = configuration["Elastic:Url"] ?? throw new NullReferenceException("Elastic Settings is missing");
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .WriteTo.Async(a => a.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUrl))
            {
                AutoRegisterTemplate = true,
                IndexFormat = $"logs-{DateTime.UtcNow:yyyy.MM.dd}",
                ModifyConnectionSettings = conn => conn
                    .ServerCertificateValidationCallback((o, cert, chain, errors) => true),
            }))
            .WriteTo.Async(a => a.Console())
            .CreateLogger();

        services.AddSingleton(Log.Logger);
        
        return services;
    }
}