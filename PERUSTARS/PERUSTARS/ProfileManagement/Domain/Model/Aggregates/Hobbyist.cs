using System.Collections.Generic;
using System.Numerics;
using User = PERUSTARS.IdentityAndAccountManagement.Domain.Model.User;

namespace PERUSTARS.ProfileManagement.Domain.Model.Aggregates
{
    public class Hobbyist: User
    {
        public BigInteger HobbyistId { get; set; }
        public User User { get; set; }
        public int Age { get; set; }
        //public List<Interest> Interests { get; set; }
        //public List<FavoriteArtwork> FavoriteArtworks { get; set; }

        public List<Follower> Followers { get; set; }
        
        public bool Collected  { get; set; } = false;

        //public List<EventAssistance> Assistance { get; set; }
    }
}