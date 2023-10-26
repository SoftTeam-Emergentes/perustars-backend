

using System.Collections.Generic;
using System.Numerics;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Enum;

namespace PERUSTARS.ProfileManagement.Interface.REST.Resources
{
    public class ArtistResource
    {
        public BigInteger ArtistId { get; set; }
        public string BrandName { get; set; } //Nickname
        public string Description { get; set; }
        public string Phrase { get; set; }
        public int ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public Genre Genre { get; set; }
        public List<Follower> Followers { get; set; }
        public List<string>SocialMediaLink { get; set; } //SocialNetwork
    }
}