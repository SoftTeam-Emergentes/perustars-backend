using System;
using MediatR;
using PERUSTARS.CommunicationAndNotificationManagement.Interfaces.REST.Resources;

namespace PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands
{
    public class NotifyNewArtworkCreatedCommand : IRequest<bool>
    {
        public long ArtworkId { get; set; }
        public long ArtistId { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Title { get; set; } //ArtowrkTitle
    }
}