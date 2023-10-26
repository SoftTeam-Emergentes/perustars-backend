using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

namespace PERUSTARS.ProfileManagement.Interface.REST.Resources
{
    public class FollowerResource
    {
        public Hobbyist Hobbyist { get; set; }
        public long HobbyistId { get; set; }

        public Artist Artist { get; set; }
        public long ArtistId { get; set; }
        public bool Collected { get; set; } = false
    }
}