using MediatR;
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Model.Commands
{
    public class RegisterUserCommand: IRequest<UserResource>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
