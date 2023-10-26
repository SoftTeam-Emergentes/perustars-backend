namespace PERUSTARS.ArtworkManagement.Domain.Model.Entities
{
    public class HobbyistFavoriteArtwork
    {
        public long Id { get; set; }
        public long ArtworkId { get; set; }
        public long HobbyistId { get; set; }

        public HobbyistFavoriteArtwork(long id, long artworkId, long hobbyistId)
        {
            Id = id;
            ArtworkId = artworkId;
            HobbyistId = hobbyistId;
        }
    }
}
