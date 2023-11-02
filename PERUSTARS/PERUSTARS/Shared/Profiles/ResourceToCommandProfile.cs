using AutoMapper;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Commands;
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;

namespace PERUSTARS.Shared.Profiles
{
    public class ResourceToCommandProfile: Profile
    {
        public ResourceToCommandProfile()
        {
            CreateMap<RegisterUserRequest, RegisterUserCommand>();
            CreateMap<AuthenticateRequest, LogInUserCommand>();
            CreateMap<RegisterArtistProfile, RegisterProfileArtistCommand>();
            CreateMap<RegisterHobbyistProfile, RegisterProfileHobbyistCommand>();
        }
    }
}
