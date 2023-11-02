﻿using System;
using MediatR;

namespace PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands
{
    public class NotifyAppliedPenaltyCommand : IRequest<bool>
    {
        public long HobbyistId { get; set; } 
        public long ArtistId { get; set; }
    }
}