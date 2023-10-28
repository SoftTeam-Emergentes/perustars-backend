using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.Commads;
using PERUSTARS.AtEventManagement.Domain.Services.ArtEvent;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Application.artevents.service
{
    public class ArtEventService : IArtEventCommandService
    {
        private IMediator _mediator;
        public ArtEventService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<string> registerArtEventService(RegisterArtEventCommand registerArtEventCommand)
        {
            string response = await _mediator.Send(registerArtEventCommand);
            return response;
        }
        public async Task<string> cancelArtEventeService(CancelArtEventCommand cancelArtEventCommand) {
            string response = await _mediator.Send(cancelArtEventCommand);
            return response;
        }

        public async Task<string> registerParticipantToArtEvent(RegisterParticipantToArtEventCommand registerParticipantToArtEventCommand)
        {
            string response = await _mediator.Send(registerParticipantToArtEventCommand);
            return response;
        }

        public async Task<string> cancelArtEvent(CancelArtEventCommand cancelArtEventCommand)
        {
            string response = await _mediator.Send(cancelArtEventCommand);
            return response;
        }

        public async Task<string> editArtEvent(EditArtEventCommand editArtEventCommand)
        {
            string response = await _mediator.Send(editArtEventCommand);
            return response;
        }

        public async Task<string> finishArtEvent(FinishArtEventCommand finishArtEventCommand)
        {
            string response = await _mediator.Send(finishArtEventCommand);
            return response;
        }

        public async Task<string> rescheduleArtEvent(RescheduleArtEventCommand rescheduleArtEventCommand)
        {
            string response = await _mediator.Send(rescheduleArtEventCommand);
            return response;
        }

        public async Task<string> startArtEventCommand(StartArtEventCommand startArtEventCommand)
        {
            string response = await _mediator.Send(startArtEventCommand);
            return response;
        }
    }
}
