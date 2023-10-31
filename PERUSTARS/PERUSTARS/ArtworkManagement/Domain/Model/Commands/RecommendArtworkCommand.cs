using MediatR;
using PERUSTARS.ArtworkManagement.Interfaces.REST.Resources;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Commands
{
    public class RecommendArtworkCommand : IRequest<ArtworkRecommendationResource>
    {
        public long HobbyistId { get; set; }
        public long ArtistId { get; set; }
        public long ArtworkId { get; set; }
    }
}
