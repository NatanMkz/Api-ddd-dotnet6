namespace Api.Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string firstName,
    string lastName,
    string email,
    string Token
);