namespace Api.Application.Services.Authentication.Queries;
using ErrorOr;
public interface IAuthenticationQuerieService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}