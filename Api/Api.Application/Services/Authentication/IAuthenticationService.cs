namespace Api.Application.Services.Authentication;
using ErrorOr;
public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string token);

    ErrorOr<AuthenticationResult> Login(string email, string password);
}