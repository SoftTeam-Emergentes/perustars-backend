using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Events;

namespace PERUSTARS.CommunicationAndNotificationManagement.Application.Events.Handlers
{
    public class FinishedEventNotifiedEventHandler : INotificationHandler<FinishedEventNotifiedEvent>
    {
        public FinishedEventNotifiedEventHandler()
        {
        }
        public async Task Handle(FinishedEventNotifiedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
