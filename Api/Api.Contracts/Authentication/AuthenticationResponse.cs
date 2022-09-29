namespace Api.Contracts.Authentication;

public record RegisterRequest(
    Guid Id,
    string firstName,
    string lastName,
    string email,
    string password
);