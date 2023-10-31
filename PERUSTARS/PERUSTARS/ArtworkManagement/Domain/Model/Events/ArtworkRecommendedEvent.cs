using MediatR;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Events
{
    public class ArtworkRecommendedEvent : INotification
    {
        public long HobbyistId { get; set; }
        public long ArtistId { get; set; }
        public long ArtworkId { get; set; }
    }
}
