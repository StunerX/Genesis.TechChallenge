using Microsoft.Extensions.DependencyInjection;

namespace Genesis.TechChallenge.Application.DependecyInjection;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services.AddMediatrModule();
        return services;
    }
}