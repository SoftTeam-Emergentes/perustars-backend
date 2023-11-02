﻿﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Events;

namespace PERUSTARS.CommunicationAndNotificationManagement.Application.Events.Handlers
{
    public class StartedEventNotifiedEventHandler : INotificationHandler<StartedArtEventNotifiedEvent>
    {
        readonly ILogger _logger;
        public StartedEventNotifiedEventHandler( ILogger<StartedEventNotifiedEventHandler> logger)
        {
            _logger = logger;
        }
        public async Task Handle(StartedArtEventNotifiedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Event has been started");
        }
    }
}