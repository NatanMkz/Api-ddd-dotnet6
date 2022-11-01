using Api.Application.Authentication.Commands.Register;
using Api.Application.Authentication.Queries.Login;
using Api.Application.Services.Authentication;
using Api.Contracts.Authentication;
using Api.Contracts.Login;
using Mapster;

namespace Api.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        .Map(dest=> dest.Token, src => src.Token)
        .Map(dest=> dest, src => src.user);
        
    }
}