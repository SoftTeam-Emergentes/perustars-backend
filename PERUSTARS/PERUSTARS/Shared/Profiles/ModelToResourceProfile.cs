using AutoMapper;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;

namespace PERUSTARS.Shared.Profiles
{
    public class ModelToResourceProfile: Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, AuthenticateResponse>();
            CreateMap<User, UserResource>();
            CreateMap<Artist, ArtistResource>();
            CreateMap<Hobbyist, HobbyistResource>();
        }
    }
}
