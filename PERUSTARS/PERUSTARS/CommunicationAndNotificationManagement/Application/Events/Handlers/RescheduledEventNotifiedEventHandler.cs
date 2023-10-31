using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Events;

namespace PERUSTARS.CommunicationAndNotificationManagement.Application.Events.Handlers
{
    public class RescheduledEventNotifiedEventHandler : INotificationHandler<RescheduledEventNotifiedEvent>
    {
        public RescheduledEventNotifiedEventHandler()
        {
        }

        public async Task Handle(RescheduledEventNotifiedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
