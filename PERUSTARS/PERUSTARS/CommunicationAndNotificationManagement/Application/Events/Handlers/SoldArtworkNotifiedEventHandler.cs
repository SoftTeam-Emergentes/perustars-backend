using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Events;
namespace PERUSTARS.CommunicationAndNotificationManagement.Application.Events.Handlers
{
    public class SoldArtworkNotifiedEventHandler : INotificationHandler<SoldArtworkNotifiedEvent>
    {
        public SoldArtworkNotifiedEventHandler()
        {
        }
        public async Task Handle(SoldArtworkNotifiedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
