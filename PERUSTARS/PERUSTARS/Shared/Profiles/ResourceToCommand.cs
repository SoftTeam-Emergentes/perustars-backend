using AutoMapper;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;

namespace PERUSTARS.Shared.Profiles
{
    public class ResourceToCommand: Profile
    {
        public ResourceToCommand()
        {
            
            CreateMap<ProfileResource, RegisterProfileArtistCommand>()
                .ForMember(a=>a.User, b=> b.MapFrom(c=>c.User))
                .ForMember(a=>a.Age,b=>b.MapFrom(c=>c.Age));
            CreateMap<ProfileResource, RegisterProfileHobbyistCommand>()
                .ForMember(a=>a.User, b=> b.MapFrom(c=>c.User))
                .ForMember(a=>a.Age,b=>b.MapFrom(c=>c.Age));

        }
    }
}