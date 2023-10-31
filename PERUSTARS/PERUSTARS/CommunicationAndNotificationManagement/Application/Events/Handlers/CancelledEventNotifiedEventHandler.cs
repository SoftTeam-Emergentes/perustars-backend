using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Events;

namespace PERUSTARS.CommunicationAndNotificationManagement.Application.Events.Handlers
{
    public class CancelledEventNotifiedEventHandler : INotificationHandler<CancelledEventNotifiedEvent>
    {
        public CancelledEventNotifiedEventHandler()
        {
        }
        public async Task Handle(CancelledEventNotifiedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
