using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.AtEventManagement.Domain.Model.Commads;
using PERUSTARS.AtEventManagement.Domain.Model.Repositories;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Application.artevents.commands
{
    public class CancelArtEventCommandHandler : IRequestHandler<CancelArtEventCommand,string>
    {
        private readonly IArtEventRepository _artEventRepository;
        public CancelArtEventCommandHandler(IMediator mediator, IArtEventRepository artEventRepository)
        {
            _artEventRepository = artEventRepository;

        }
        public Task<string> Handle(CancelArtEventCommand request, CancellationToken cancellationToken)
        {
            ArtEvent artEvent = _artEventRepository.FindByIdAsync(request.id).Result;
            if (artEvent != null)
            {
                artEvent.CurrentStatus = ArtEventStatus.CANCELLED;
                _artEventRepository.Update(artEvent);
                return Task.FromResult("Event updated!!!");
            }
            else {
                return Task.FromResult("The event with the given id doesn't exist");
            }
        }
    }
}
