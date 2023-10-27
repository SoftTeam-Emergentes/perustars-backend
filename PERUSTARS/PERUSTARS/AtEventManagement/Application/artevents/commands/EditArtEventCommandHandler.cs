using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.AtEventManagement.Domain.Model.Commads;
using PERUSTARS.AtEventManagement.Domain.Model.Repositories;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Application.artevents.commands
{
    public class EditArtEventCommandHandler : IRequestHandler<EditArtEventCommand, string>
    {
        private readonly IArtEventRepository _artEventRepository;
        public EditArtEventCommandHandler(IArtEventRepository artEventRepository)
        {
            _artEventRepository = artEventRepository;
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
                return await Task.FromResult("Art event edited succesfully!!");
            }
            else {
                return await Task.FromResult("Art event with the given id doesn't exist");
            }
        }
    }
}
