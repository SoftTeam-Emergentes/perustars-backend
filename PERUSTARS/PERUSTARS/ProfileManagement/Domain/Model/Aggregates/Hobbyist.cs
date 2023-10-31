using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PERUSTARS.ArtworkManagement.Domain.Model.Entities;
<<<<<<< HEAD
using User = PERUSTARS.IdentityAndAccountManagement.Domain.Model.User;
=======
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;
>>>>>>> 2fee3da5ad887de408f6ed620d123f3bf2f009cd

namespace PERUSTARS.ProfileManagement.Domain.Model.Aggregates
{
    public class Hobbyist : User
    {
        
        public long HobbyistId { get; set; }
        public User User { get; set; }
        
        [ForeignKey("User")]
        public long UserId { get; set; }
        public int Age { get; set; }
        //public List<Interest> Interests { get; set; }
        public List<HobbyistFavoriteArtwork> FavoriteArtworks { get; set; }
        public List<ArtworkReview> ArtworkReviews { get; set; }
        public List<ArtworkRecommendation> ArtworkRecommendations { get; set; }
        public List<Follower> FollowedArtists { get; set; }
        public List<Participant> Participants { get; set; }
        
        public bool Collected  { get; set; } = false;
        //public List<EventAssistance> Assistance { get; set; }
        
        public Hobbyist(long hobbyistId, User user, long userId, int age, List<HobbyistFavoriteArtwork> favoriteArtworks, List<ArtworkReview> artworkReviews, List<ArtworkRecommendation> artworkRecommendations, List<Follower> followedArtists, List<Participant> participants, bool collected)
        {
            HobbyistId = hobbyistId;
            User = user;
            UserId = userId;
            Age = age;
            FavoriteArtworks = favoriteArtworks;
            ArtworkReviews = artworkReviews;
            ArtworkRecommendations = artworkRecommendations;
            FollowedArtists = followedArtists;
            Participants = participants;
            Collected = collected;
        }
       
    }
}