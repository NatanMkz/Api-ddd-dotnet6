using Api.Application.Common.Interfaces.Authentication;
using Api.Application.Common.Interfaces.Persistence;
using Api.Application.Common.Interfaces.Services;
using Api.Infrastructure.Authentication;
using Api.Infrastructure.Persistence;
using Api.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        Microsoft.Extensions.Configuration.ConfigurationManager configuration
        )
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}