using ErrorOr;

namespace Api.Domain.Common.Errors;
public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail", description: "Email já está sendo utilizado");
    }
}