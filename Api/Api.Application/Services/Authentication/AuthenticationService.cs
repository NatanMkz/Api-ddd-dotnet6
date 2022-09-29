using Api.Application.Common.Interfaces.Authentication;
using Api.Application.Common.Interfaces.Persistence;
using Api.Domain.Entities;

namespace Api.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //1. Verificar se o usuário existe

            if(_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("Usuário já existe");
            }

        //2. Criar o usuario (generate unique ID) & persistencia de dados
        var user = new User{FirstName = firstName, LastName = lastName, Email = email, Password = password};

        _userRepository.Add(user);

        //3. Criar o Token JWT

        Guid userId = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        // 1. Validar se o usuário existe
            if(_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("Não existe um usuário com este email");
            }
        // 2. Validar se a senhas está correta 

            if(user.Password != password)
            {
                throw new Exception("Senha incorreta");
            }

        // 3. Gerar o token de acesso

        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(user, token);
    }
}