using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Events;

namespace PERUSTARS
{
    public class StartedEventNotifiedEventHandler : INotificationHandler<StartedEventNotifiedEvent>
    {
            
        public StartedEventNotifiedEventHandler()
        {
        }
        public async Task Handle(StartedEventNotifiedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
