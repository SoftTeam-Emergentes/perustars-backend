namespace PERUSTARS.ArtworkManagement.Interfaces.REST.Resources
{
    public class HobbyistFavoriteArtworkResource
    {
        public long Id { get; set; }
        public long ArtworkId { get; set; }
        public long HobbyistId { get; set; }
    }
}
