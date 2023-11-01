using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Events;

namespace PERUSTARS.CommunicationAndNotificationManagement.Application.Events.Handlers
{
    public class PenaltyAppliedNotifiedEventHandler : INotificationHandler<PenaltyAppliedNotifiedEvent>
    {
        readonly ILogger _logger;    
        public PenaltyAppliedNotifiedEventHandler(ILogger<PenaltyAppliedNotifiedEventHandler> logger)
        {   
            _logger = logger;
        }
        public async Task Handle(PenaltyAppliedNotifiedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Penalty has been applied");
        }
    }
}
