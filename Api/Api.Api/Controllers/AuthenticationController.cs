using Api.Application.Services.Authentication;
using Api.Contracts.Authentication;
using Api.Contracts.Login;
using Microsoft.AspNetCore.Mvc;

namespace Api.Api.Controllers;
[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(request.firstName, request.lastName, request.email, request.password);
        var response = new AuthenticationResult(authResult.user, authResult.Token);
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(request.Email, request.Password);
        var response = new AuthenticationResult(authResult.user, authResult.Token);
        return Ok(response);
    }
}