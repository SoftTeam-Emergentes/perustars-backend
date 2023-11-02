﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Events;

namespace PERUSTARS.CommunicationAndNotificationManagement.Application.Events.Handlers
{
    public class NewArtworkCreatedNotifiedEventHandler : INotificationHandler<NewArtworkCreatedNotifiedEvent>
    {
        readonly ILogger _logger;
        public NewArtworkCreatedNotifiedEventHandler(ILogger<NewArtworkCreatedNotifiedEventHandler> logger)
        {
            _logger = logger;
        }
        public async Task Handle(NewArtworkCreatedNotifiedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("New Artwork has been created");
        }
    }

}