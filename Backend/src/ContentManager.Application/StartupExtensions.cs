using ContentManager.Application.Users;
using ContentManager.Rest.Api.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContentManager.Application;

public static class StartupExtensions
{
    public static IServiceCollection Application(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(x => 
            x.RegisterServicesFromAssemblyContaining<CreateUser>());

        services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
        
        return services;
    }
}