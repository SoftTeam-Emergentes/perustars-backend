using System.Collections.Generic;
using System.Numerics;
using PERUSTARS.ProfileManagement.Domain.Model.Enum;
using User = PERUSTARS.IdentityAndAccountManagement.Domain.Model.User;


namespace PERUSTARS.ProfileManagement.Domain.Model.Entities
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

        //public IList<Artwork> Artworks { get; set; } = new List<Artwork>();

        //public List<Event> Events { get; set; }

        public List<Follower> Followers { get; set; }
    }
}