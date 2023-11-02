using AutoMapper;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;

namespace PERUSTARS.Shared.Profiles
{
    public class ResourceToModelProfile: Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<UserResource, User>();
            CreateMap<ArtistResource, Artist>();
            CreateMap<HobbyistResource, Hobbyist>();
        }
    }
}
