using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Events;

namespace PERUSTARS.CommunicationAndNotificationManagement.Application.Events.Handlers
{
    public class PenaltyAppliedNotifiedEventHandler : INotificationHandler<PenaltyAppliedNotifiedEvent>
    {
            
            public PenaltyAppliedNotifiedEventHandler()
            {
            }
            public async Task Handle(PenaltyAppliedNotifiedEvent notification, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
    }
}
