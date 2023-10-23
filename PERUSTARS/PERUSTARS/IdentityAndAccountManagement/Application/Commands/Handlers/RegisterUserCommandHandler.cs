using AutoMapper;
using MediatR;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Commands;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Events;
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.IdentityAndAccountManagement.Application.Commands.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserResource>
    {
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        

        public RegisterUserCommandHandler(IPublisher publisher, IMapper mapper)
        {
            _publisher = publisher;
            _mapper = mapper;
        }

        public async Task<UserResource> Handle(RegisterUserCommand registerUserCommand, CancellationToken cancellationToken)
        {
            // TODO: Registrar Usuario como sabemos hacerlo
            UserResource userResource = new UserResource();
            // Realizar algún mapeo
            UserRegisteredEvent userRegisteredEvent = new UserRegisteredEvent()
            {
                UserId = 1
            };
            await _publisher.Publish(userRegisteredEvent);
            return userResource;
        }
    }
}
