using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Events;

namespace PERUSTARS.CommunicationAndNotificationManagement.Application.Events.Handlers
{
    public class FollowedArtistNotifiedEventHandler : INotificationHandler<FollowedArtistNotifiedEvent>
    {
        readonly ILogger _logger;
        public FollowedArtistNotifiedEventHandler(ILogger<FollowedArtistNotifiedEventHandler> logger)
        {
            _logger = logger;
        }
        public async Task Handle(FollowedArtistNotifiedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Artist has been followed");
        }
    }
}
