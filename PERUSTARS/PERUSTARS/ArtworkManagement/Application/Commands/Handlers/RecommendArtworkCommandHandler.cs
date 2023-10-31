using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PERUSTARS.ArtworkManagement.Application.Exceptions;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;
using PERUSTARS.ArtworkManagement.Domain.Model.Entities;
using PERUSTARS.ArtworkManagement.Domain.Model.Events;
using PERUSTARS.ArtworkManagement.Domain.Repositories;
using PERUSTARS.ArtworkManagement.Interfaces.REST.Resources;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Persistence;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtworkManagement.Application.Commands.Handlers
{
    public class RecommendArtworkCommandHandler : IRequestHandler<RecommendArtworkCommand, ArtworkResource>
    {
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly IArtworkRepository _artworkRepository;
        private readonly IHobbyistRepository _hobbyistRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IArtworkRecommendationRepository _artworkRecommendationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RecommendArtworkCommandHandler(IPublisher publisher, IMapper mapper, IArtworkRepository artworkRepository, IUnitOfWork unitOfWork)
        {
            _publisher = publisher;
            _mapper = mapper;
            _artworkRepository = artworkRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ArtworkResource> Handle(RecommendArtworkCommand request, CancellationToken cancellationToken)
        {
            var existingArtwork = await _artworkRepository.FindArtworkByIdAsync(request.ArtworkId);
            if (existingArtwork == null)
            {
                throw new ArtworkNotFoundException("Artwork not found");
            }

            var existingHobbyist = new Hobbyist(); // TODO: await _hobbyistRepository.FindHobbyistByIdAsync(request.HobbyistId);
            if (existingHobbyist == null)
            {
                throw new ApplicationException("Hobbyist not found");
                // TODO: throw new HobbyistNotFoundException("Hobbyist not found");
            }

            var existingArtist = new Artist(); // TODO: await _artistRepository.FindArtistByIdAsync(request.ArtistId);
            if (existingArtist == null)
            {
                throw new ApplicationException("Artist not found");
                // TODO: throw new ArtistNotFoundException("Artist not found");
            }

            var existingArtworkRecommendation = new ArtworkRecommendation(); // TODO: await _artworkRecommendationRepository.FindArtworkRecommendationByHobbyistIdAndArtistIdAndArtworkIdAsync(request.HobbyistId, request.ArtistId, request.ArtworkId);
            if (existingArtworkRecommendation != null)
            {
                throw new ApplicationException("Artwork recommendation already exists");
            }

            var artworkRecommendation = _mapper.Map<ArtworkRecommendation>(request);

            try
            {
                await _artworkRecommendationRepository.AddAsync(artworkRecommendation);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new ApplicationException($"An error occurred while saving the artwork recommendation: {e.Message}");
            }

            ArtworkRecommendedEvent artworkRecommendedEvent = new ArtworkRecommendedEvent()
            {
                ArtworkId = request.ArtworkId,
                HobbyistId = request.HobbyistId,
                ArtistId = request.ArtistId
            };

            await _publisher.Publish(artworkRecommendedEvent);

            return _mapper.Map<ArtworkResource>(artworkRecommendation);
        }
    }
}
