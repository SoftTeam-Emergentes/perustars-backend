using MediatR;
using PERUSTARS.ArtworkManagement.Domain.Model.ValueObjects;
using PERUSTARS.ArtworkManagement.Interfaces.REST.Resources;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Commands
{
    public class UploadArtworkCommand : IRequest<ArtworkResource>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ArtworkContent MainContent { get; set; }
        public float Price { get; set; }
        public ArtworkContent CoverImage { get; set; }
        public long ArtistId { get; set; }
    }
}
