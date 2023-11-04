using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PERUSTARS.Shared.Domain.Repositories;
using PERUSTARS.ArtworkManagement.Domain.Repositories;
using PERUSTARS.ArtworkManagement.Domain.Model.Events;
using PERUSTARS.ArtworkManagement.Domain.Model.Entities;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;
using PERUSTARS.ArtworkManagement.Application.Exceptions;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ArtworkManagement.Interfaces.REST.Resources;
using PERUSTARS.ProfileManagement.Domain.Repositories;

namespace PERUSTARS.ArtworkManagement.Application.Commands.Handlers
{
    public class ReviewArtworkCommandHandler : IRequestHandler<ReviewArtworkCommand, ArtworkReviewResource>
    {
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly IArtworkRepository _artworkRepository;
        private readonly IHobbyistRepository _hobbyistRepository;
        private readonly IArtworkReviewRepository _artworkReviewRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewArtworkCommandHandler(IPublisher publisher, IMapper mapper, IArtworkRepository artworkRepository, IHobbyistRepository hobbyistRepository, IArtworkReviewRepository artworkReviewRepository, IUnitOfWork unitOfWork)
        {
            _publisher = publisher;
            _mapper = mapper;
            _artworkRepository = artworkRepository;
            _hobbyistRepository = hobbyistRepository;
            _artworkReviewRepository = artworkReviewRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ArtworkReviewResource> Handle(ReviewArtworkCommand request, CancellationToken cancellationToken)
        {
            var existingArtwork = await _artworkRepository.FindArtworkByIdAsync(request.ArtworkId);
            if (existingArtwork == null)
            {
                throw new ArtworkNotFoundException("Artwork not found");
            }

            var existingHobbyist = await _hobbyistRepository.GetHobbyistByIdAsync(request.HobbyistId);
            if (existingHobbyist == null)
            {
                throw new ApplicationException("Hobbyist not found");
            }

            var existingArtworkReview = await _artworkReviewRepository.FindArtworkReviewByHobbyistIdAndArtworkIdAsync(request.HobbyistId, request.ArtworkId);
            if (existingArtworkReview != null)
            {
                throw new ApplicationException($"Artwork already reviewed by hobbyist id: {existingHobbyist.HobbyistId}");
            }

            var artworkReview = _mapper.Map<ArtworkReview>(request);

            try
            {
                await _artworkReviewRepository.AddAsync(artworkReview);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new ApplicationException($"An error occurred while reviewing artwork: {e.Message}");
            }

            ArtworkReviewedEvent artworkReviewedEvent = new ArtworkReviewedEvent()
            {
                Id = artworkReview.Id,
                ArtworkId = artworkReview.ArtworkId,
                HobbyistId = artworkReview.HobbyistId,
                Title = artworkReview.Title,
                Comment = artworkReview.Comment,
                ReviewDateTime = artworkReview.ReviewDateTime,
                Calification = artworkReview.Calification
            };

            await _publisher.Publish(artworkReviewedEvent);

            return _mapper.Map<ArtworkReviewResource>(artworkReview);
        }
    }
}
