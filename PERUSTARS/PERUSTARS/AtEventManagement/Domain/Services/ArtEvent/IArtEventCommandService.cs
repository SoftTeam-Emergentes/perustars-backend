using PERUSTARS.AtEventManagement.Domain.Model.Commads;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Domain.Services.ArtEvent
{
    public interface IArtEventCommandService
    {
        Task<string> registerArtEventService(RegisterArtEventCommand registerArtEventCommand);
        Task<string> registerParticipantToArtEvent(RegisterParticipantToArtEventCommand registerParticipantToArtEventCommand);
        Task<string> cancelArtEvent(CancelArtEventCommand cancelArtEventCommand);
        Task<string> editArtEvent(EditArtEventCommand editArtEventCommand);
        Task<string> finishArtEvent(FinishArtEventCommand finishArtEventCommand);
        Task<string> rescheduleArtEvent(RescheduleArtEventCommand rescheduleArtEventCommand);
        Task<string> startArtEventCommand(StartArtEventCommand startArtEventCommand);
        Task<string> deleteArtEvent(DeleteArtEventCommand deleteArtEventCommand);
    }
}
