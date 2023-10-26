using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Events;

namespace PERUSTARS.IdentityAndAccountManagement.Application.Events.Handlers;

public class GeneratedJwtTokenEventHandler: INotificationHandler<GeneratedJwtTokenEvent>
{
    private ILogger _logger;

    public GeneratedJwtTokenEventHandler(ILogger logger)
    {
        _logger = logger;
    }
    
    public async Task Handle(GeneratedJwtTokenEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Generated token: {notification.Token}");
    }
}