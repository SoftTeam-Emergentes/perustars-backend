﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Events;

namespace PERUSTARS.CommunicationAndNotificationManagement.Application.Events.Handlers
{
    public class FinishedEventNotifiedEventHandler : INotificationHandler<FinishedArtEventNotifiedEvent>
    {
        readonly ILogger _logger;
        public FinishedEventNotifiedEventHandler(ILogger<FinishedEventNotifiedEventHandler> logger)
        {
            _logger = logger;
        }
        public async Task Handle(FinishedArtEventNotifiedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Art Event has finished");
        }
    }
}