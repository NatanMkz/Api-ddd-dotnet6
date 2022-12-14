using Api.Application;
using Api.Infrastructure;
using Api.Application.Services.Authentication;
using Api.Api.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Api.Api.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Api.Api;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddAplication()
        .AddInfrastructure(builder.Configuration);
    //builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    
}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");

    // app.Map("/error", (HttpContext httpContext) =>
    // {
    //     Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    //     return Results.Problem();
    // });

    app.UseAuthentication();
    app.UseAuthorization();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
