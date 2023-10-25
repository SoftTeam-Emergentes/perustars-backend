namespace PERUSTARS.ProfileManagement.Domain.Model.Aggregates
{
    public class Follower
    {
        public Hobbyist Hobbyist { get; set; }
        public long HobbyistId { get; set; }

        public Artist Artist { get; set; }
        public long ArtistId { get; set; }
    }
}