using Api.Application;
using Api.Infrastructure;
using Api.Application.Services.Authentication;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddAplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
