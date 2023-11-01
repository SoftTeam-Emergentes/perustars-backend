using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Events;

namespace PERUSTARS.CommunicationAndNotificationManagement.Application.Events.Handlers
{
    public class RescheduledArtEventNotifiedEventHandler : INotificationHandler<RescheduledArtEventNotifiedEvent>
    {
        readonly ILogger _logger;
        public RescheduledArtEventNotifiedEventHandler(ILogger<RescheduledArtEventNotifiedEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(RescheduledArtEventNotifiedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Art Event has been rescheduled");
        }
    }

}
