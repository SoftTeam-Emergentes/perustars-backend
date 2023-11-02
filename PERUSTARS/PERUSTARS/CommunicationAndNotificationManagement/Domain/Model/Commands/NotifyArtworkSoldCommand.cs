using MediatR;
using PERUSTARS.CommunicationAndNotificationManagement.Interfaces.REST.Resources;
using PERUSTARS.ArtworkManagement.Domain.Model.Enums;

namespace PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands
{
    public class NotifyArtworkSoldCommand : IRequest<bool>
    {
        public long ArtworkId { get; set; }
        public long ArtistId { get; set; }
        public ArtworkStatus Status { get; set; }
        public float Price { get; set; }
        public string ArtworkTitle { get; set; }
    }
}