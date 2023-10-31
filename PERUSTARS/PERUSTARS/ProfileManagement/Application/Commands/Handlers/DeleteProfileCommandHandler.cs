using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PERUSTARS.ProfileManagement.Application.Exceptions;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Domain.Repositories;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ProfileManagement.Application.Commands.Handlers
{
    public class DeleteProfileArtistCommandHandler :IRequestHandler<DeleteProfileArtistCommand>
    
    {
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProfileArtistCommandHandler(IPublisher publisher, IMapper mapper, IArtistRepository artistRepository, IUnitOfWork unitOfWork)
        {
            _publisher = publisher;
            _mapper = mapper;
            _artistRepository = artistRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteProfileArtistCommand request, CancellationToken cancellationToken)
        {
            var artistProfile = await _artistRepository.GetArtistByIdAsync(request.ArtistId);
            if (artistProfile == null)
            {
                throw new ProfileNotFoundException("Profile not found");
            }

            bool success = await _artistRepository.DeleteArtistProfileAsync(artistProfile);
            if (!success)
            {
                throw new ProfileDeletionException("The profile was not deleted");
            } 
            
        } 
    }
    
    public class DeleteProfileHobbyistCommandHandler :IRequestHandler<DeleteProfileHobbyistCommand>
    
    {
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly IHobbyistRepository _hobbyistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProfileHobbyistCommandHandler(IPublisher publisher, IMapper mapper, IHobbyistRepository hobbyistRepository, IUnitOfWork unitOfWork)
        {
            _publisher = publisher;
            _mapper = mapper;
            _hobbyistRepository = hobbyistRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteProfileHobbyistCommand request, CancellationToken cancellationToken)
        {
            var hobbyistProfile = await _hobbyistRepository.GetHobbyistByIdAsync(request.HobbyistId);
            if (hobbyistProfile == null)
            {
                throw new ProfileNotFoundException("Profile not found");
            }

            bool success = await _hobbyistRepository.DeleteHobbyistProfileAsync(hobbyistProfile);
            if (!success)
            {
                throw new ProfileDeletionException("The profile was not deleted");
            }
        } 
    }
}