using MediatR;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Commands
{
    public class ReviewArtworkCommand : IRequest<string>
    {
        public long ArtworkId { get; set; }
        public long HobbyistId { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public float Calification { get; set; }
    }
}
