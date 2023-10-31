using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Commands;
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;
using System.Threading.Tasks;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Services
{
    public interface IIdentityAndAccountManagementCommandService
    {
        Task<UserResource> ExecuteRegisterUserCommand(RegisterUserCommand registerUserCommand);
        Task<AuthenticateResponse> ExecuteLogInUserCommand(LogInUserCommand logInUserCommand);
    }
}
