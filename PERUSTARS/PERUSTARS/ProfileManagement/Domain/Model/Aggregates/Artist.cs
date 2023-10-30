using System.Collections.Generic;
using System.Numerics;
using PERUSTARS.ArtworkManagement.Domain.Model.Aggregates;
using PERUSTARS.ArtworkManagement.Domain.Model.Entities;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Enum;
using User = PERUSTARS.IdentityAndAccountManagement.Domain.Model.User;



namespace PERUSTARS.ProfileManagement.Domain.Model.Aggregates
{
    public class Artist : User
    {
        public BigInteger ArtistId { get; set; }
        
        public User User { get; set; }
        public string BrandName { get; set; } //Nickname
        public string Description { get; set; }
        public string Phrase { get; set; }
        public int ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public int Age { get; set; }
        public Genre Genre { get; set; }
        
        public List<string>SocialMediaLink { get; set; } //SocialNetwork

        //public long SpecialtyId { get; set; }
        //public Specialty SpecialtyArt { get; set; }

        public List<Artwork> Artworks { get; set; }
        public List<ArtworkRecommendation> ArtworkRecommendations { get; set; }
        public List<ArtEvent> ArtEvents { get; set; }
        public List<Follower> Followers { get; set; }
        
        public bool Collected  { get; set; } = false;
    }
}