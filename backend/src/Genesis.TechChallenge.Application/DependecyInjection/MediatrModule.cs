using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Genesis.TechChallenge.Application.DependecyInjection;

public static class MediatrModule
{
    public static IServiceCollection AddMediatrModule(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}