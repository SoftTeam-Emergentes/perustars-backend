using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PERUSTARS.ProfileManagement.Domain.Model.Enum;

namespace PERUSTARS.ProfileManagement.Interface.REST.Resources
{
    public class ArtistEditResource
    {
        [ForeignKey("User")]

        public int Age { get; set; }
        public string BrandName { get; set; } //Nickname
        public string Description { get; set; }
        public string Phrase { get; set; }
        public int ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public Genre Genre { get; set; }
        public List<string> SocialMediaLink { get; set; }
    }
}

