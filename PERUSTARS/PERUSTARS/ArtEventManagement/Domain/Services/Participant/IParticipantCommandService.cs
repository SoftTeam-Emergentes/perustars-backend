using System.Threading.Tasks;
using PERUSTARS.ArtEventManagement.Domain.Model.Commads;

namespace PERUSTARS.ArtEventManagement.Domain.Services.Participant
{
    public interface IParticipantCommandService
    {
        Task<string> deleteParticipant(DeleteParticipantCommand deleteParticipantCommand);
    }
}
