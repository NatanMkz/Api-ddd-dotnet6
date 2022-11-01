using Api.Api.Common.Errors;
using Api.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Api.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {

        services.AddMappings();
        services.AddControllers();

        services.AddSingleton<ProblemDetailsFactory, ApiProblemDetailsFactory>();
        return services;
    }
}