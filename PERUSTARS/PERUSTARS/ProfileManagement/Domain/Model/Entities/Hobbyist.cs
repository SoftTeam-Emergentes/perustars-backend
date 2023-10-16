using System.Collections.Generic;
using System.Numerics;
using PERUSTARS.Domain.Models;

namespace PERUSTARS.ProfileManagement.Domain.Model.Entities
{
    public class Hobbyist
    {
        public BigInteger HobbyisttId { get; set; }
        public List<Interest> Interests { get; set; }
        public List<FavoriteArtwork> FavoriteArtworks { get; set; }

        public List<Follower> Followers { get; set; }

        public List<EventAssistance> Assistance { get; set; }
    }
}