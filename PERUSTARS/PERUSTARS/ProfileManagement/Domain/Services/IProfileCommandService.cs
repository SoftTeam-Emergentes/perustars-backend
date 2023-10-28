
using System.Threading.Tasks;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;

namespace PERUSTARS.ProfileManagement.Domain.Services
{
    public interface IProfileCommandService
    {
        Task<ArtistResource> ExecuteRegisterProfileCommand(RegisterProfileArtistCommand artistProfileCommand);
        Task<HobbyistResource> ExecuteRegisterProfileCommand(RegisterProfileHobbyistCommand hobbyistProfileCommand);
        
    }
}