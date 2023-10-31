using MediatR;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Commands
{
    public class DeleteArtworkCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
