using ErrorOr;
using MediatR;
using Api.Application.Services.Authentication;

namespace Api.Application.Authentication.Commands.Register
{

    public record RegisterCommand(string FirstName, string LastName, string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;

}