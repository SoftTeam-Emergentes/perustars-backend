using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.ArtEventManagement.Domain.Model.Commads;
using PERUSTARS.ArtEventManagement.Domain.Model.Repositories;
using PERUSTARS.ArtEventManagement.Domain.Model.ValueObjects;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtEventManagement.Application.ArtEvents.Commands
{
    public class FinishArtEventCommandHandler : IRequestHandler<FinishArtEventCommand, string>
    {
        private readonly IArtEventRepository _artEventRepository;
        private readonly IUnitOfWork _unitOfWork;
        public FinishArtEventCommandHandler(IArtEventRepository artEventRepository, IUnitOfWork unitOfWork)
        {
            _artEventRepository = artEventRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(FinishArtEventCommand request, CancellationToken cancellationToken)
        {
            ArtEvent artevent = await _artEventRepository.FindByIdAsync(request.artEventId);
            if (artevent != null)
            {
                artevent.CurrentStatus = ArtEventStatus.CANCELLED;
                _artEventRepository.Update(artevent);
                await _unitOfWork.CompleteAsync();
                return "Evento marcado como finalizado";
            }
            else {
                return "The art event with the given id doesn't exist";
            }
        }
    }
}
