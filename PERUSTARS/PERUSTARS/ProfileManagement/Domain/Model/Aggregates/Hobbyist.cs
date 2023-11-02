using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using System.Collections.Generic;
using System.Numerics;
using PERUSTARS.ArtworkManagement.Domain.Model.Entities;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;

namespace PERUSTARS.ProfileManagement.Domain.Model.Aggregates
{
    public class Hobbyist: User
    {
        public long HobbyistId { get; set; }
        public User User { get; set; }
        public int Age { get; set; }
        //public List<Interest> Interests { get; set; }
        public List<HobbyistFavoriteArtwork> FavoriteArtworks { get; set; }
        public List<ArtworkReview> ArtworkReviews { get; set; }
        public List<ArtworkRecommendation> ArtworkRecommendations { get; set; }
        public List<Follower> Followers { get; set; }
        public List<Participant> Participants { get; set; }
        
        public bool Collected  { get; set; } = false;
        public IEnumerable<Participant> Participants { get; set; }
        //public List<EventAssistance> Assistance { get; set; }
    }
}