using MediatR;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Commands
{
    public class RecommendArtworkCommand : IRequest<string>
    {
        public long HobyistId { get; set; }
        public long ArtistId { get; set; }
        public long ArtworkId { get; set; }
    }
}
