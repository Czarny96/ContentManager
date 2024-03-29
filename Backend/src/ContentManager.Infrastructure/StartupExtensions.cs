using System.Reflection;
using ContentManager.Application;
using ContentManager.Application.Abstractions;
using ContentManager.Application.Users;
using ContentManager.Domain;
using ContentManager.Domain.Projects;
using ContentManager.Infrastructure.EntityFramework;
using ContentManager.Infrastructure.MediatR;
using ContentManager.Infrastructure.Users;
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
        services.AddScoped<IDbContext>(provider => provider.GetRequiredService<ContentManagerDbContext>());
            
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(Validator<,>));
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<IProjectRepository, IProjectRepository>();
        services.AddScoped<IJwtService, JwtServices>();
        
        return services;
    }
}