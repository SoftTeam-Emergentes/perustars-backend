using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PERUSTARS.Shared.Domain.Repositories;
using PERUSTARS.ArtworkManagement.Domain.Repositories;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;
using PERUSTARS.ArtworkManagement.Application.Exceptions;

namespace PERUSTARS.ArtworkManagement.Application.Commands.Handlers
{
    public class DeleteArtworkCommandHandler : IRequestHandler<DeleteArtworkCommand>
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
            var artwork = await _artworkRepository.FindArtworkByIdAsync(request.Id);
            if (artwork == null)
            {
                throw new ArtworkNotFoundException("Artwork not found");
            }

            bool success = await _artworkRepository.RemoveArtworkAsync(artwork);
            if (!success)
            {
                throw new ArtworkDeletionException("The artwork was not deleted");
            }

            return Unit.Value;
        }
    }
}
