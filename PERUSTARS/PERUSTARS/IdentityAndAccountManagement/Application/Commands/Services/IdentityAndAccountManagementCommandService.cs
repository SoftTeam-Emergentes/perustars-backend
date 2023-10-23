using MediatR;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Commands;
using PERUSTARS.IdentityAndAccountManagement.Domain.Services;
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;
using System.Threading.Tasks;

namespace PERUSTARS.IdentityAndAccountManagement.Application.Commands.Services
{
    public class IdentityAndAccountManagementCommandService: IIdentityAndAccountManagementCommandService
    {
        private readonly IMediator _mediator;
        public IdentityAndAccountManagementCommandService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<UserResource> executeRegisterUserCommand(RegisterUserCommand registerUserCommand)
        {
            return await _mediator.Send(registerUserCommand);
        }
    }
}
