using PERUSTARS.AtEventManagement.Domain.Model.Commads;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Domain.Services.ArtEvent
{
    public interface IArtEventCommandService
    {
        Task<string> registerArtEventService(RegisterArtEventCommand registerArtEventCommand);
    }
}
