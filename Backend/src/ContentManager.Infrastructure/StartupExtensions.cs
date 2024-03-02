using System.Reflection;
using ContentManager.Application.Abstractions;
using ContentManager.Infrastructure.EntityFramework;
using ContentManager.Infrastructure.MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ContentManager.Infrastructure;

public static class StartupExtensions
{
    public static IServiceCollection Infrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ContentManagerDbContext>(options =>
            options.UseSqlServer(connectionString, sql => sql.EnableRetryOnFailure())
        );

        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ContentManagerDbContext>());
            
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(Validator<,>));
        });
        return services;
    }
}