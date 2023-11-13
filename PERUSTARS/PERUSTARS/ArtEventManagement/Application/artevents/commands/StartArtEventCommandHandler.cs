using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.ArtEventManagement.Domain.Model.Commads;
using PERUSTARS.ArtEventManagement.Domain.Model.Repositories;
using PERUSTARS.ArtEventManagement.Domain.Model.ValueObjects;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtEventManagement.Application.artevents.commands
{
    public class StartArtEventCommandHandler : IRequestHandler<StartArtEventCommand, string>
    {
        private readonly IArtEventRepository _artEventRepository;
        private readonly IUnitOfWork _unitOfWork;
        public StartArtEventCommandHandler(IArtEventRepository artEventRepository,IUnitOfWork unitOfWork)
        {
            _artEventRepository = artEventRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(StartArtEventCommand request, CancellationToken cancellationToken)
        {
            ArtEvent artEvent = await _artEventRepository.FindByIdAsync(request.id);
            if (artEvent == null)
            {

                return "Something went wrong";
            }
            else
            {
                artEvent.CurrentStatus = ArtEventStatus.STARTED;
                _artEventRepository.Update(artEvent);
                _unitOfWork.CompleteAsync();
                return "Event started!!";

            }
        }
    }
}
