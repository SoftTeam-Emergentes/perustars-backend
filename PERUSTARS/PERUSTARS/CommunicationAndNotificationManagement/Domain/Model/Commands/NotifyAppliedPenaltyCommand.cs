using System;
using MediatR;
using PERUSTARS.CommunicationAndNotificationManagement.Interfaces.REST.Resources;

namespace PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands
{
    public class NotifyAppliedPenaltyCommand : IRequest<bool>
    {
        public long HobbyistId { get; set; } 
        public long ArtistId { get; set; }
    }
}
