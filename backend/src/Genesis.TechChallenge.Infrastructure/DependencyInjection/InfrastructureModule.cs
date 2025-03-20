using System.Diagnostics.CodeAnalysis;
using Genesis.TechChallenge.Domain.Services;
using Genesis.TechChallenge.Domain.ValueObjects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Genesis.TechChallenge.Infrastructure.DependencyInjection;

/// <summary>
/// Infrastructure Module
/// </summary>
[ExcludeFromCodeCoverage]
public static class InfrastructureModule
{
    /// <summary>
    /// Add Infrastructure Module
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(new CdiRate(0.009m));
        services.AddScoped<ICdbCalculator, CdbCalculator>();

        return services;
    }
}