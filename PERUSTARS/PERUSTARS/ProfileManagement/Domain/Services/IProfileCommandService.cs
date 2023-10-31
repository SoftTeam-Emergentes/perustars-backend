using System.Threading.Tasks;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;

namespace PERUSTARS.ProfileManagement.Domain.Services
{
    public interface IProfileCommandService
    {
        Task<ArtistResource> executeRegisterProfileCommand(RegisterProfileArtistCommand artistProfileCommand);
        Task<HobbyistResource> executeRegisterProfileCommand(RegisterProfileHobbyistCommand hobbyistProfileCommand);
    }
}