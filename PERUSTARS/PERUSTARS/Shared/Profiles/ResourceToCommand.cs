using AutoMapper;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;

namespace PERUSTARS.Shared.Profiles
{
    public class ResourceToCommand: Profile
    {
        public ResourceToCommand()
        {

            CreateMap<ArtistResource, RegisterProfileArtistCommand>();
            CreateMap<HobbyistResource, RegisterProfileHobbyistCommand>();
        }
    }
}