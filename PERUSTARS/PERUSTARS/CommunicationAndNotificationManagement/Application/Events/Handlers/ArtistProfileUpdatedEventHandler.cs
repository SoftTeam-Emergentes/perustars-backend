using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Events;

namespace PERUSTARS
{
    public class ArtistProfileUpdatedEventHandler : INotificationHandler<ArtistProfileUpdatedEvent>
    {
            
        public ArtistProfileUpdatedEventHandler()
        {
        }
        public async Task Handle(ArtistProfileUpdatedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
