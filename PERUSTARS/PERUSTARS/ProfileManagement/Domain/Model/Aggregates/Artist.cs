using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Enum;



namespace PERUSTARS.ProfileManagement.Domain.Model.Aggregates
{
    public class Artist 
    {
        public long ArtistId { get; set; }
        
        public User User { get; set; }
        
        [ForeignKey("User")]
        public long UserId { get; set; }
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
        [JsonIgnore]
        [ForeignKey("Follower")]
        public List<Follower> FollowersArtist { get; set; }

        public Follower Follower { get; set; }
        
        public bool Collected  { get; set; } = false;
    }
}