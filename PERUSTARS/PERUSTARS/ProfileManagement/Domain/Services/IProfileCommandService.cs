
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;

namespace PERUSTARS.ProfileManagement.Domain.Services
{
    public interface IProfileCommandService
    {
        Task<ArtistResource> ExecuteRegisterProfileCommand(RegisterProfileArtistCommand artistProfileCommand);
        Task<HobbyistResource> ExecuteRegisterProfileCommand(RegisterProfileHobbyistCommand hobbyistProfileCommand);

        Task<Unit> ExecuteDeleteProfileCommand(DeleteProfileArtistCommand deleteProfileArtistCommand);

        Task<Unit> ExecuteDeleteProfileCommand(DeleteProfileHobbyistCommand deleteProfileHobbyistCommand);

        Task<HobbyistResource> ExecuteEditProfileCommand(EditProfileHobbyistCommand editProfileHobbyistCommand);

        Task<ArtistResource> ExecuteEditProfileCommand(EditProfileArtistCommand editProfileArtistCommand);

        Task<Unit> ExecuteFollowArtistCommand(FollowArtistCommand followArtistCommand);

    }
}