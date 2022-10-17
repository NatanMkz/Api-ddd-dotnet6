using Api.Application;
using Api.Infrastructure;
using Api.Application.Services.Authentication;
using Api.Api.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Api.Api.Errors;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddAplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();

    builder.Services.AddSingleton<ProblemDetailsFactory, ApiProblemDetailsFactory>();
}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");

    app.Map("/error", (HttpContext httpContext) => {
        Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        return Results.Problem();
    });
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
