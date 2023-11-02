using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PERUSTARS.ArtworkManagement.Application.Exceptions;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;
using PERUSTARS.ArtworkManagement.Domain.Model.Entities;
using PERUSTARS.ArtworkManagement.Domain.Repositories;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Repositories;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtworkManagement.Application.Commands.Handlers
{
    public class AssignFavoriteArtworkCommandHandler : IRequestHandler<AssignFavoriteArtworkCommand, Unit>
    {

        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly IHobbyistRepository _hobbyistRepository;
        private readonly IArtworkRepository _artworkRepository;
        private readonly IHobbyistFavoriteArtworkRepository _hobbyistFavoriteArtworkRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AssignFavoriteArtworkCommandHandler(IPublisher publisher, IMapper mapper, IHobbyistRepository hobbyistRepository, IArtworkRepository artworkRepository, IHobbyistFavoriteArtworkRepository hobbyistFavoriteArtworkRepository, IUnitOfWork unitOfWork)
        {
            _publisher = publisher;
            _mapper = mapper;
            _hobbyistRepository = hobbyistRepository;
            _artworkRepository = artworkRepository;
            _hobbyistFavoriteArtworkRepository = hobbyistFavoriteArtworkRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AssignFavoriteArtworkCommand request, CancellationToken cancellationToken)
        {
            var existingHobbyist = new Hobbyist(); // TODO: await _hobbyistRepository.FindHobbyistByIdAsync(request.HobbyistId);
            if (existingHobbyist == null)
            {
                throw new ApplicationException("Hobbyist not found");
            }

            var existingArtwork = await _artworkRepository.FindArtworkByIdAsync(request.ArtworkId);
            if (existingArtwork == null)
            {
                throw new ArtworkNotFoundException($"Artwork not found with id: {request.ArtworkId}");
            }

            var existingHobbyistFavoriteArtwork = await _hobbyistFavoriteArtworkRepository.FindHobbyistFavoriteArtworkByHobbyistIdAndArtworkIdAsync(request.HobbyistId, request.ArtworkId);
            if (existingHobbyistFavoriteArtwork != null)
            {
                throw new ApplicationException($"Favorite artwork already was assigned with hobbyist id: {request.HobbyistId} and artwork id: {request.ArtworkId}");
            }

            var hobbyistFavoriteArtwork = _mapper.Map<HobbyistFavoriteArtwork>(request);

            try
            {
                await _hobbyistFavoriteArtworkRepository.AddAsync(hobbyistFavoriteArtwork);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new ApplicationException($" An error occurred while assigning the favorite artwork: {e.Message}");
            }

            return Unit.Value;
        }
    }
}
