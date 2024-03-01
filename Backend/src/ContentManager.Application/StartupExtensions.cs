using Microsoft.Extensions.DependencyInjection;

namespace ContentManager.Application;

public static class StartupExtensions
{
    public static IServiceCollection Application(this IServiceCollection services)
    {
        return services;
    }
}