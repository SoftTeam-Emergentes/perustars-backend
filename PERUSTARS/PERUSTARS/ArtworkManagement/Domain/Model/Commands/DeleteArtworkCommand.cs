using MediatR;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Commands
{
    public class DeleteArtworkCommand : IRequest<string>
    {
        public long Id { get; set; }
    }
}
