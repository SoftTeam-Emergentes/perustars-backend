using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.AtEventManagement.Domain.Model.Commads;
using PERUSTARS.AtEventManagement.Domain.Model.Repositories;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Application.artevents.commands
{
    public class RescheduleArtEventCommandHandler : IRequestHandler<RescheduleArtEventCommand, string>
    {
        private readonly IArtEventRepository _artEventRepository;
        public RescheduleArtEventCommandHandler(IArtEventRepository artEventRepository)
        {
            _artEventRepository = artEventRepository;
        }
        public async Task<string> Handle(RescheduleArtEventCommand request, CancellationToken cancellationToken)
        {
            ArtEvent artEvent = await _artEventRepository.FindByIdAsync(request.id);
            if (artEvent != null)
            {
                artEvent.StartDateTime = request.newDate;
                artEvent.CurrentStatus = ArtEventStatus.RESCHEDULED;
                _artEventRepository.Update(artEvent);
                return await Task.FromResult("Art Event rescheduled!!");
            }
            else {
                return await Task.FromResult("The art event with the given id doesn't exist");
            }
        }

    }
}
