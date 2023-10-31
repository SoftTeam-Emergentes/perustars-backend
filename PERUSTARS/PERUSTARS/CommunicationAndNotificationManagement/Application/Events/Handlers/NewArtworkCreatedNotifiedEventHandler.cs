using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Events;

namespace PERUSTARS.CommunicationAndNotificationManagement.Application.Events.Handlers
{
    public class NewArtworkCreatedNotifiedEventHandler : INotificationHandler<NewArtworkCreatedNotifiedEvent>
    {
        
        public NewArtworkCreatedNotifiedEventHandler()
        {
        }
        public async Task Handle(NewArtworkCreatedNotifiedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
