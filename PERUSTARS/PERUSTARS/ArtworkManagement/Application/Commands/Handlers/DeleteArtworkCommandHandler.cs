using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PERUSTARS.Shared.Domain.Repositories;
using PERUSTARS.ArtworkManagement.Domain.Repositories;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;
using PERUSTARS.ArtworkManagement.Application.Exceptions;
using System;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;

namespace PERUSTARS.ArtworkManagement.Application.Commands.Handlers
{
    public class DeleteArtworkCommandHandler : IRequestHandler<DeleteArtworkCommand, Unit>
    {
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly IArtworkRepository _artworkRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteArtworkCommandHandler(IPublisher publisher, IMapper mapper, IArtworkRepository artworkRepository, IUnitOfWork unitOfWork)
        {
            _publisher = publisher;
            _mapper = mapper;
            _artworkRepository = artworkRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Unit> Handle(DeleteArtworkCommand request, CancellationToken cancellationToken)
        {
            var existingArtist = new Artist(); // TODO: await _artistRepository.FindArtistByIdAsync(request.ArtistId);
            if (existingArtist == null)
            {
                throw new ApplicationException("Artist not found");
            }

            var existingArtwork = await _artworkRepository.FindArtworkByIdAsync(request.Id);
            if (existingArtwork == null)
            {
                throw new ArtworkNotFoundException("Artwork not found");
            }

            bool success = await _artworkRepository.RemoveArtworkAsync(existingArtwork);
            if (!success)
            {
                throw new ArtworkDeletionException("The artwork was not deleted");
            }

            return Unit.Value;
        }
    }
}
