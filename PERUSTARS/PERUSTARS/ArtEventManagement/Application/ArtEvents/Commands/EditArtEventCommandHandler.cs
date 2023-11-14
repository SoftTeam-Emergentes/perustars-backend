using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.ArtEventManagement.Domain.Model.Commads;
using PERUSTARS.ArtEventManagement.Domain.Model.Repositories;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtEventManagement.Application.ArtEvents.Commands
{
    public class EditArtEventCommandHandler : IRequestHandler<EditArtEventCommand, string>
    {
        private readonly IArtEventRepository _artEventRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EditArtEventCommandHandler(IArtEventRepository artEventRepository, IUnitOfWork unitOfWork)
        {
            _artEventRepository = artEventRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(EditArtEventCommand request, CancellationToken cancellationToken)
        {
            ArtEvent artEvent = await _artEventRepository.FindByIdAsync(request.id);
            if (artEvent == null)
            {
                artEvent.Title = request.title;
                artEvent.Description = request.description;
                artEvent.Location = request.location;
                artEvent.IsOnline = request.isOnline;
                _artEventRepository.Update(artEvent);
                await _unitOfWork.CompleteAsync();
                return "Art event edited succesfully!!";
            }
            else {
                return "Art event with the given id doesn't exist";
            }
        }
    }
}
