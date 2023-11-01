using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model;
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;
using PERUSTARS.ProfileManagement.Domain.Model.Enum;

namespace PERUSTARS.ProfileManagement.Interface.REST.Resources
{
    public class RegisterArtistProfile
    {
        [Required]
        public string BrandName { get; set; }
        public string Description { get; set; }
        public string Phrase { get; set; }
        public int ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public Genre Genre { get; set; }
        public List<string>SocialMediaLink { get; set; }
    }
}