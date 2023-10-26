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
    }
}
