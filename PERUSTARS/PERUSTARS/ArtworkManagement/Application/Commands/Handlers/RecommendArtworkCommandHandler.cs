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
using PERUSTARS.ProfileManagement.Application.Exceptions;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Repositories;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtworkManagement.Application.Commands.Handlers
{
    public class RecommendArtworkCommandHandler : IRequestHandler<RecommendArtworkCommand, ArtworkRecommendationResource>
    {
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly IArtworkRepository _artworkRepository;
        private readonly IHobbyistRepository _hobbyistRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IArtworkRecommendationRepository _artworkRecommendationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RecommendArtworkCommandHandler(IPublisher publisher, IMapper mapper, IArtworkRepository artworkRepository, IHobbyistRepository hobbyistRepository, IArtistRepository artistRepository, IArtworkRecommendationRepository artworkRecommendationRepository, IUnitOfWork unitOfWork)
        {
            _publisher = publisher;
            _mapper = mapper;
            _artworkRepository = artworkRepository;
            _hobbyistRepository = hobbyistRepository;
            _artistRepository = artistRepository;
            _artworkRecommendationRepository = artworkRecommendationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ArtworkRecommendationResource> Handle(RecommendArtworkCommand request, CancellationToken cancellationToken)
        {
            var existingArtwork = await _artworkRepository.FindArtworkByIdAsync(request.ArtworkId);
            if (existingArtwork == null)
            {
                throw new ArtworkNotFoundException("Artwork not found");
            }

            var existingHobbyist = await _hobbyistRepository.GetHobbyistByIdAsync(request.HobbyistId);
            if (existingHobbyist == null)
            {
                throw new ProfileNotFoundException("Hobbyist not found");
            }

            var existingArtist = await _artistRepository.GetArtistByIdAsync(request.ArtistId);
            if (existingArtist == null)
            {
                throw new ProfileNotFoundException("Artist not found");
            }

            var existingArtworkRecommendation = await _artworkRecommendationRepository.FindArtworkRecommendationByHobbyistIdAndArtistIdAndArtworkIdAsync(request.HobbyistId, request.ArtistId, request.ArtworkId);
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

            return _mapper.Map<ArtworkRecommendationResource>(artworkRecommendation);
        }
    }
}
