using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;
using PERUSTARS.ProfileManagement.Domain.Model.Enum;

namespace PERUSTARS.ProfileManagement.Interface.REST.Resources
{
    public class GetAllArtistsResource
    {
        public long ArtistId { get; set; }
        public int Age { get; set; }
        public string BrandName { get; set; } //Nickname
        public string Description { get; set; }
        public string Phrase { get; set; }
        public int ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public Genre Genre { get; set; }
        public UserResource User { get; set; }
    }
}
