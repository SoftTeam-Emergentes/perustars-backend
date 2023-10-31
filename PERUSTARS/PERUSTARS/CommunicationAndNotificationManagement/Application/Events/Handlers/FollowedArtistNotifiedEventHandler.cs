using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Events;

namespace PERUSTARS.CommunicationAndNotificationManagement.Application.Events.Handlers
{
    public class FollowedArtistNotifiedEventHandler : INotificationHandler<FollowedArtistNotifiedEvent>
    {
        
        public FollowedArtistNotifiedEventHandler()
        {
        }
        public async Task Handle(FollowedArtistNotifiedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
