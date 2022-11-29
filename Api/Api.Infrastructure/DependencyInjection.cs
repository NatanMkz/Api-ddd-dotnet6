using System.Text;
using Api.Application.Common.Interfaces.Authentication;
using Api.Application.Common.Interfaces.Persistence;
using Api.Application.Common.Interfaces.Services;
using Api.Infrastructure.Authentication;
using Api.Infrastructure.Persistence;
using Api.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Api.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        services.AddAuth(configuration).AddPersistence();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        

        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();

        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        var JwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, JwtSettings);
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton(Options.Create(JwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = JwtSettings.Issuer,
            ValidAudience = JwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.Secret))
        });
        return services;
    }

}