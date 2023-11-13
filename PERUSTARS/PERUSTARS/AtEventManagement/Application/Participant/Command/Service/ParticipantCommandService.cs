using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.Commads;
using PERUSTARS.AtEventManagement.Domain.Services.Participant;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Application.Participant.Command.Service
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
