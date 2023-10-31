using MediatR;
using PERUSTARS.ArtworkManagement.Domain.Model.Enums;
using PERUSTARS.ArtworkManagement.Domain.Model.ValueObjects;
using PERUSTARS.ArtworkManagement.Interfaces.REST.Resources;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Commands
{
    public class EditArtworkCommand : IRequest<ArtworkResource>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ArtworkContent MainContent { get; set; }
        public float Price { get; set; }
        public ArtworkContent CoverImage { get; set; }
        public ArtworkStatus Status { get; set; }
        public long ArtistId { get; set; }
    }
}
