using Api.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}