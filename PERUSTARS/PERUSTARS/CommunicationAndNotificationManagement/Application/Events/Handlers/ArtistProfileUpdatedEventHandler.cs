﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Events;

namespace PERUSTARS.CommunicationAndNotificationManagement.Application.Events.Handlers
{
    public class ArtistProfileUpdatedEventHandler : INotificationHandler<ArtistProfileUpdatedEvent>
    {
        //logger  
        ILogger _logger;

        public ArtistProfileUpdatedEventHandler(ILogger<ArtistProfileUpdatedEventHandler> logger)
        {
            _logger = logger;
        }
        public async Task Handle(ArtistProfileUpdatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Artist Profile has been Updated");
        }
    }

}