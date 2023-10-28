using MediatR;
using Microsoft.Extensions.Logging;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Events;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.IdentityAndAccountManagement.Application.Events.Handlers
{
    public class UserRegisteredEventHandler : INotificationHandler<UserRegisteredEvent>
    {
        //private ILogger _logger;
        public UserRegisteredEventHandler(/*ILogger<UserRegisteredEventHandler> logger*/)
        {
            //_logger = logger;
        }
        public async Task Handle(UserRegisteredEvent userRegisteredEvent, CancellationToken cancellationToken)
        {
            //_logger.LogInformation($"User with id {userRegisteredEvent.UserId}");
        }
    }
}
