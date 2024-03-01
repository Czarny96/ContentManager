using Microsoft.Extensions.DependencyInjection;

namespace ContentManager.Infrastructure;

public static class StartupExtensions
{
    public static IServiceCollection Infrastructure(this IServiceCollection services)
    {
        return services;
    }
}