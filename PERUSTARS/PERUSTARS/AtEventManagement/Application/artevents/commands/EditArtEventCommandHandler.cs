using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.AtEventManagement.Domain.Model.Commads;
using PERUSTARS.AtEventManagement.Domain.Model.Repositories;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;
using PERUSTARS.Shared.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Application.artevents.commands
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
