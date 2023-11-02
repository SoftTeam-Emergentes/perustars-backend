using System.Collections.Generic;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

namespace PERUSTARS.ProfileManagement.Interface.REST.Resources
{
    public class GetArtistFollowers
    {
        public long ArtistId { get; set; }
        public long UserId { get; set; }
        public List<Follower> FollowersArtist { get; set; }
    }
}

