using System.Reflection;
using ContentManager.Infrastructure.MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ContentManager.Infrastructure;

public static class StartupExtensions
{
    public static IServiceCollection Infrastructure(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(Validator<,>));
        });
        return services;
    }
}