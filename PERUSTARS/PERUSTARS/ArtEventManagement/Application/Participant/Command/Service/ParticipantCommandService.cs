using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtEventManagement.Domain.Model.Commads;
using PERUSTARS.ArtEventManagement.Domain.Services.Participant;

namespace PERUSTARS.ArtEventManagement.Application.Participant.Command.Service
{
    public class ParticipantCommandService:IParticipantCommandService
    {
        private readonly IMediator _mediator;
        public ParticipantCommandService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string> deleteParticipant(DeleteParticipantCommand deleteParticipantCommand)
        {
            return await _mediator.Send(deleteParticipantCommand);
        }
    }
}
