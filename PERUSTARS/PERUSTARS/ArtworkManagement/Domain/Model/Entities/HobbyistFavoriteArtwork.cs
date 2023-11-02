using PERUSTARS.ArtworkManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Entities
{
    public class HobbyistFavoriteArtwork
    {
        public long Id { get; set; }
        public long ArtworkId { get; set; }
        public Artwork Artwork { get; set; }
        public long HobbyistId { get; set; }
        public Hobbyist Hobbyist { get; set; }
    }
}
