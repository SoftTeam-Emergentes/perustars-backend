using System;
using MediatR;
using PERUSTARS.CommunicationAndNotificationManagement.Interfaces.REST.Resources;

namespace PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands
{
    public class NotifyUpdatedArtistProfileCommand : IRequest<bool>
    {
        public long ArtistId { get; set; }
        public string BrandName { get; set; } //Nickname
    }
}
