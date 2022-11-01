using Api.Application.Services.Authentication.Commands;
using Api.Application.Services.Authentication.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {        

        services.AddMediatR(typeof(DependencyInjection).Assembly);

        return services;
    }
}