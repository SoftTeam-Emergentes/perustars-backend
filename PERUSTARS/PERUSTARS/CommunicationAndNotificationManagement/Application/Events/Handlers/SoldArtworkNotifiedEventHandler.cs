using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Events;
namespace PERUSTARS.CommunicationAndNotificationManagement.Application.Events.Handlers
{
    public class SoldArtworkNotifiedEventHandler : INotificationHandler<SoldArtworkNotifiedEvent>
    {
        readonly ILogger _logger;
        public SoldArtworkNotifiedEventHandler(ILogger<SoldArtworkNotifiedEventHandler> logger)
        {
            _logger = logger;
        }
        
        public async Task Handle(SoldArtworkNotifiedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Artwork has been sold");
        }
    }
}
