﻿using MediatR;
using PERUSTARS.CommunicationAndNotificationManagement.Interfaces.REST.Resources;

namespace PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands
{
    public class NotifyFollowedArtistCommand : IRequest<bool>
    {
        public long ArtistId { get; set; }
        public long HobbyistId { get; set; }
    }
}