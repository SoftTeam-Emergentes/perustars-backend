using PERUSTARS.AtEventManagement.Domain.Model.Commads;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Domain.Services.Participant
{
    public interface IParticipantCommandService
    {
        Task<string> deleteParticipant(DeleteParticipantCommand deleteParticipantCommand);
    }
}
