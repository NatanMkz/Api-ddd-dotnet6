using Api.Domain.Entities;

namespace Api.Application.Services.Authentication;

public record AuthenticationResult(
    User user,
    string Token
    );