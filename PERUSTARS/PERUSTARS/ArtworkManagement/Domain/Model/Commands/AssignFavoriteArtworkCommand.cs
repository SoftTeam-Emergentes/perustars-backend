using MediatR;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Commands
{
    public class AssignFavoriteArtworkCommand : IRequest<Unit>
    {
        public long HobbyistId { get; set; }
        public long ArtworkId { get; set; }
    }
}