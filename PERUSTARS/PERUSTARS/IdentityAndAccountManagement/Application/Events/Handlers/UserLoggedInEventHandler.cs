using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Events;

namespace PERUSTARS.IdentityAndAccountManagement.Application.Events.Handlers;

public class UserLoggedInEventHandler: INotificationHandler<UserLoggedInEvent>
{
    private ILogger _logger;

    public UserLoggedInEventHandler(ILogger logger)
    {
        _logger = logger;
    }
    public async Task Handle(UserLoggedInEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"User with id {notification.UserId}");
    }
}