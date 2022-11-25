using System.Reflection;
using Api.Application.Authentication.Commands.Register;
using Api.Application.Services.Authentication;
using Api.Application.Services.Authentication.Commands;
using Api.Application.Services.Authentication.Queries;
using Api.Application.Common.Behaviors;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Api.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {        

        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        //services.AddScoped<IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>, ValidationBehavior>();
        //services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}