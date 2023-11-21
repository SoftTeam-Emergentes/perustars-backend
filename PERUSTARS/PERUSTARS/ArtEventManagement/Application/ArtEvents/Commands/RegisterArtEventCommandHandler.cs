using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.ArtEventManagement.Domain.Model.Commads;
using PERUSTARS.ArtEventManagement.Domain.Model.Repositories;
using PERUSTARS.ArtEventManagement.Domain.Model.ValueObjects;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Repositories;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtEventManagement.Application.ArtEvents.Commands
{
    public class RegisterArtEventCommandHandler : IRequestHandler<RegisterArtEventCommand, string>
    {
        private readonly IArtEventRepository _artEventRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArtistRepository _artistRepository;
        public RegisterArtEventCommandHandler(IArtEventRepository artEventRepository, IUnitOfWork unitOfWork,IArtistRepository artist)
        {
            _artEventRepository = artEventRepository;
            _unitOfWork = unitOfWork;
            _artistRepository = artist;
        }

        public async Task<string> Handle(RegisterArtEventCommand request, CancellationToken cancellationToken)
        {
            //Primero se debe validar si existe el artista con el Id dado
            Artist artist=await _artistRepository.GetArtistByIdAsync(request.ArtistId);
            //"return No existe el Artista con el Id dado"
            //-----------------------------------
            if(artist==null) {
                return "This artist doesn't exist!!";
            }

            var artEvent = new ArtEvent(
                title: request.Title,
                description: request.Description,
                startDateTime: request.StartDateTime,
                Location: request.Location,
                isOnline: request.IsOnline,
                artistId: request.ArtistId,
                Artist:artist
                );
            await _artEventRepository.AddAsync(artEvent);
            await _unitOfWork.CompleteAsync();
            return "Art event registered succesfully!!";

        }
    }
}
