namespace Api.Application.Services.Authentication.Commands;
using ErrorOr;
public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string token);
}