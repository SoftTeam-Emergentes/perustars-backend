using System.Collections.Generic;
using System.Numerics;
using MediatR;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Enum;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;

namespace PERUSTARS.ProfileManagement.Domain.Model.Commands
{
   //ArtistResource
    public class EditProfileArtistCommand: IRequest<ArtistResource>
    {
        
        public int Age { get; set; }
        public long ArtistId { get; set; }
        public string BrandName { get; set; } //Nickname
        public string Description { get; set; }
        public string Phrase { get; set; }
        public int ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public Genre Genre { get; set; }
        public List<string>SocialMediaLink { get; set; } //SocialNetwork
    }
 
    
    public class EditProfileHobbyistCommand : IRequest<HobbyistResource>
    {
        public int Age { get; set; }
        public long HobbyistId { get; set; }
        public List<Follower> Followers { get; set; }
    }

}