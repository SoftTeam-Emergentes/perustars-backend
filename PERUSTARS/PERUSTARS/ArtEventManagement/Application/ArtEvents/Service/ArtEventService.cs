﻿using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtEventManagement.Domain.Model.Commads;
using PERUSTARS.ArtEventManagement.Domain.Services.ArtEvent;

namespace PERUSTARS.ArtEventManagement.Application.ArtEvents.Service
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
            return await _mediator.Send(registerArtEventCommand);
        }
        public async Task<string> cancelArtEventeService(CancelArtEventCommand cancelArtEventCommand) {
            return await _mediator.Send(cancelArtEventCommand);
        }

        public async Task<string> registerParticipantToArtEvent(RegisterParticipantToArtEventCommand registerParticipantToArtEventCommand)
        {
            return await _mediator.Send(registerParticipantToArtEventCommand);
        }

        public async Task<string> cancelArtEvent(CancelArtEventCommand cancelArtEventCommand)
        {
            return await _mediator.Send(cancelArtEventCommand);
        }

        public async Task<string> editArtEvent(EditArtEventCommand editArtEventCommand)
        {
            return await _mediator.Send(editArtEventCommand);
        }

        public async Task<string> finishArtEvent(FinishArtEventCommand finishArtEventCommand)
        {
            return await _mediator.Send(finishArtEventCommand);
        }

        public async Task<string> rescheduleArtEvent(RescheduleArtEventCommand rescheduleArtEventCommand)
        {
            return await _mediator.Send(rescheduleArtEventCommand);
        }

        public async Task<string> startArtEventCommand(StartArtEventCommand startArtEventCommand)
        {
            return await _mediator.Send(startArtEventCommand);
        }

        public async Task<string> deleteArtEvent(DeleteArtEventCommand deleteArtEventCommand) {
            return await _mediator.Send(deleteArtEventCommand);
        }
    }
}
