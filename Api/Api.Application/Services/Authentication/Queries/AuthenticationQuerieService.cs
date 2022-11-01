using Api.Application.Common.Interfaces.Authentication;
using Api.Application.Common.Interfaces.Persistence;
using Api.Domain.Common.Errors;
using Api.Domain.Entities;
using ErrorOr;
namespace Api.Application.Services.Authentication.Queries;

public class AuthenticationQuerieService : IAuthenticationQuerieService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQuerieService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    // public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    // {
    //     //1. Verificar se o usuário existe

    //         if(_userRepository.GetUserByEmail(email) is not null)
    //         {
    //            return Errors.User.DuplicateEmail;
    //         }

    //     //2. Criar o usuario (generate unique ID) & persistencia de dados
    //     var user = new User{FirstName = firstName, LastName = lastName, Email = email, Password = password};

    //     _userRepository.Add(user);

    //     //3. Criar o Token JWT

    //     Guid userId = Guid.NewGuid();

    //     var token = _jwtTokenGenerator.GenerateToken(user);

    //     return new AuthenticationResult(user, token);
    // }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        // 1. Validar se o usuário existe
            if(_userRepository.GetUserByEmail(email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }
        // 2. Validar se a senhas está correta 

            if(user.Password != password)
            {
                return new[] { Errors.Authentication.InvalidCredentials };
            }

        // 3. Gerar o token de acesso

        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(user, token);
    }
}