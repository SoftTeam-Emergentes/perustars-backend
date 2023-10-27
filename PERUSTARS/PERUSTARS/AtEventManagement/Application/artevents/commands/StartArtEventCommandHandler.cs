using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.AtEventManagement.Domain.Model.Commads;
using PERUSTARS.AtEventManagement.Domain.Model.Repositories;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Application.artevents.commands
{
    public class StartArtEventCommandHandler : IRequestHandler<StartArtEventCommand, string>
    {
        private readonly IArtEventRepository _artEventRepository;
        public StartArtEventCommandHandler(IArtEventRepository artEventRepository)
        {
            _artEventRepository = artEventRepository;
        }

        public async Task<string> Handle(StartArtEventCommand request, CancellationToken cancellationToken)
        {
            ArtEvent artEvent = await _artEventRepository.FindByIdAsync(request.id);
            if (artEvent == null)
            {
                return await Task.FromResult("Something went wrong");
            }
            else
            {
                artEvent.CurrentStatus = ArtEventStatus.STARTED;
                return await Task.FromResult("Event started!!");

            }
        }
    }
}
