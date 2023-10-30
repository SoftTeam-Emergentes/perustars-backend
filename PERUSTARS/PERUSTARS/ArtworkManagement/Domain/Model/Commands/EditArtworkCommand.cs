using MediatR;
using PERUSTARS.ArtworkManagement.Domain.Model.Enums;
using PERUSTARS.ArtworkManagement.Domain.Model.ValueObjects;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Commands
{
    public class EditArtworkCommand : IRequest<string>
    {
        public long ArtworkId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ArtworkContent MainContent { get; set; }
        public float Price { get; set; }
        public ArtworkContent CoverImage { get; set; }
        public ArtworkStatus Status { get; set; }
        public long ArtistId { get; set; }
    }
}
