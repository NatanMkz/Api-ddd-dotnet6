using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Services.Authentication;
using ErrorOr;
using MediatR;

namespace Api.Application.Authentication.Queries.Login
{

    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;

}