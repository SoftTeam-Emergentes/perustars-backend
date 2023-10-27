using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.AtEventManagement.Domain.Model.Commads;
using PERUSTARS.AtEventManagement.Domain.Model.Repositories;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Application.artevents.commands
{
    public class FinishArtEventCommandHandler : IRequestHandler<FinishArtEventCommand, string>
    {
        private readonly IArtEventRepository _artEventRepository;
        public FinishArtEventCommandHandler(IArtEventRepository artEventRepository)
        {
            _artEventRepository = artEventRepository;
        }
        public async Task<string> Handle(FinishArtEventCommand request, CancellationToken cancellationToken)
        {
            ArtEvent artevent = await _artEventRepository.FindByIdAsync(request.artEventId);
            if (artevent != null)
            {
                artevent.CurrentStatus = ArtEventStatus.CANCELLED;
                _artEventRepository.Update(artevent);
                return await Task.FromResult("Evento marcado como finalizado");
            }
            else {
                return await Task.FromResult("The art event with the given id doesn't exist");
            }
        }
    }
}
