using System.Text;
using ContentManager.Rest.Api.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ContentManager.Api;

public static class StartupExtensions
{
    public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration, bool requireHttps)
    {
        var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

        if (jwtOptions!.Name != "ContentManager")
        {
            throw new ArgumentException(@"Missing configuration for ContentManager in JwtOptions.");
        }

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(jwtOptions.Name!, options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Secret!)),
#pragma warning disable CA5404
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
#pragma warning restore CA5404
                ValidateLifetime = true,
            };
            options.RequireHttpsMetadata = requireHttps;
        });
        
        return services;
    }
    
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter JWT value"
            });
        });

        return services;
    }
}