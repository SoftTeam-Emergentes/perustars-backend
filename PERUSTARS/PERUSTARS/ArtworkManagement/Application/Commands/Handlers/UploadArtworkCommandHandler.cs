using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PERUSTARS.Shared.Domain.Repositories;
using PERUSTARS.ArtworkManagement.Domain.Repositories;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;
using PERUSTARS.ArtworkManagement.Interfaces.REST.Resources;
using System;
using PERUSTARS.ProfileManagement.Domain.Persistence;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ArtworkManagement.Domain.Model.Aggregates;
using PERUSTARS.ArtworkManagement.Domain.Model.Events;

namespace PERUSTARS.ArtworkManagement.Application.Commands.Handlers
{
    public class UploadArtworkCommandHandler : IRequestHandler<UploadArtworkCommand, ArtworkResource>
    {
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;
        private readonly IArtworkRepository _artworkRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UploadArtworkCommandHandler(IPublisher publisher, IMapper mapper, IArtworkRepository artworkRepository, IUnitOfWork unitOfWork)
        {
            _publisher = publisher;
            _mapper = mapper;
            _artworkRepository = artworkRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ArtworkResource> Handle(UploadArtworkCommand request, CancellationToken cancellationToken)
        {
            var existingArtist = new Artist(); // TODO: await _artistRepository.FindArtistByIdAsync(request.ArtistId);
            if (existingArtist == null)
            {
                throw new ApplicationException("Artist not found");
            }

            var existingArtwork = await _artworkRepository.FindArtworkByArtistIdAndTitleAsync(request.ArtistId, request.Title);
            if (existingArtwork != null)
            {
                throw new ApplicationException($"Artwork already exists with title: {request.Title} and artist id: {request.ArtistId}");
            }

            var artwork = _mapper.Map<Artwork>(request);

            try
            {
                await _artworkRepository.AddAsync(artwork);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new ApplicationException($" An error occurred while saving the artwork: {e.Message}");
            }

            ArtworkUploadedEvent artworkUploadedEvent = new ArtworkUploadedEvent()
            {
                Id = artwork.Id,
                Title = artwork.Title,
                Description = artwork.Description,
                MainContent = artwork.MainContent,
                Price = artwork.Price,
                CoverImage = artwork.CoverImage,
                PublishedAt = artwork.PublishedAt,
                Status = artwork.Status,
                ArtistId = artwork.ArtistId
            };

            await _publisher.Publish(artworkUploadedEvent);

            return _mapper.Map<ArtworkResource>(artwork);
        }
    }
}
