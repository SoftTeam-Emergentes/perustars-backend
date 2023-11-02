using AutoMapper;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;

namespace PERUSTARS.Shared.Profiles;

public class CommandToModelProfile: Profile
{
    public CommandToModelProfile()
    {
        CreateMap<RegisterUserCommand, User>();
        CreateMap<RegisterProfileArtistCommand, Artist>();
        CreateMap<RegisterProfileHobbyistCommand, Hobbyist>();
        CreateMap<EditProfileArtistCommand, Artist>();
        CreateMap<EditProfileHobbyistCommand, Hobbyist>();
        CreateMap<DeleteProfileArtistCommand, Artist>();
        CreateMap<DeleteProfileHobbyistCommand, Hobbyist>();
        CreateMap<FollowArtistCommand, Follower>();
    }
}