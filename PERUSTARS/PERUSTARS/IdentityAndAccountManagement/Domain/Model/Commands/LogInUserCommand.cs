using MediatR;
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Model.Commands;

public class LogInUserCommand: IRequest<AuthenticateResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}