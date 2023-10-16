using System.Collections.Generic;
using System.Numerics;
using PERUSTARS.Domain.Models;


namespace PERUSTARS.ProfileManagement.Domain.Model.Entities
{
    public class Artist
    {
        public BigInteger ArtistId { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public string Phrase { get; set; }

        public List<string>SocialMediaLink { get; set; }

        public long SpecialtyId { get; set; }
        public Specialty SpecialtyArt { get; set; }

        public IList<Artwork> Artworks { get; set; } = new List<Artwork>();

        public List<Event> Events { get; set; }

        public List<Follower> Followers { get; set; }
    }
}