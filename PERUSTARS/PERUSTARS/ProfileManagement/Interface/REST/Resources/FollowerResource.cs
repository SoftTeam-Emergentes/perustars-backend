using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

namespace PERUSTARS.ProfileManagement.Interface.REST.Resources
{
    public class FollowerResource
    {
        public long HobbyistId { get; set; }
        public long ArtistId { get; set; }
    }
}