using System;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PERUSTARS.Shared.Domain.Repositories;
using PERUSTARS.ArtworkManagement.Domain.Repositories;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;
using PERUSTARS.ArtworkManagement.Application.Exceptions;
using PERUSTARS.ArtworkManagement.Interfaces.REST.Resources;

namespace PERUSTARS.ArtworkManagement.Application.Commands.Handlers
{
    public class EditArtworkCommandHandler : IRequestHandler<EditArtworkCommand, ArtworkResource>
    {
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly IArtworkRepository _artworkRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EditArtworkCommandHandler(IPublisher publisher, IMapper mapper, IArtworkRepository artworkRepository, IUnitOfWork unitOfWork)
        {
            _publisher = publisher;
            _mapper = mapper;
            _artworkRepository = artworkRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ArtworkResource> Handle(EditArtworkCommand request, CancellationToken cancellationToken)
        {
            var existingArtwork = await _artworkRepository.FindArtworkByIdAsync(request.Id);
            if (existingArtwork == null)
            {
                throw new ArtworkNotFoundException("Artwork not found");
            }

            existingArtwork.Title = request.Title;
            existingArtwork.Description = request.Description;
            existingArtwork.MainContent = request.MainContent;
            existingArtwork.Price = request.Price;
            existingArtwork.CoverImage = request.CoverImage;
            existingArtwork.Status = request.Status;
            existingArtwork.ArtistId = request.ArtistId;

            try
            {
                _artworkRepository.Update(existingArtwork);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new ApplicationException($"An error occurred while saving the artwork: {e.Message}");
            }

            return _mapper.Map<ArtworkResource>(existingArtwork);
        }
    }
}
