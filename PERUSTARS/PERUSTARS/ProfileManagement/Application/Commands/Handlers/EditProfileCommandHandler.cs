using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PERUSTARS.ProfileManagement.Application.Exceptions;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Domain.Repositories;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ProfileManagement.Application.Commands.Handlers
{
    public class EditProfileArtistCommandHandler: IRequestHandler<EditProfileArtistCommand, ArtistResource>
    {
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public EditProfileArtistCommandHandler(IPublisher publisher, IMapper mapper, IArtistRepository artistRepository, IUnitOfWork unitOfWork)
        {
            _publisher = publisher;
            _mapper = mapper;
            _artistRepository = artistRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ArtistResource> Handle(EditProfileArtistCommand editProfileArtistCommand,
            CancellationToken cancellationToken)
        {
            var existingArtist = await _artistRepository.GetArtistByIdAsync(editProfileArtistCommand.ArtistId);

            if (existingArtist == null)
            {
                throw new ProfileNotFoundException("Profile not found");
            }

            if (_artistRepository.ExistsByBrandName(editProfileArtistCommand.BrandName) &&
                editProfileArtistCommand.BrandName != existingArtist.BrandName)
            {
                throw new ApplicationException($"Brandname '{editProfileArtistCommand.BrandName}' is already taken.");
            }
            
            _mapper.Map(editProfileArtistCommand, existingArtist);

            try
            {
                await _unitOfWork.CompleteAsync();

            }
            catch (Exception e)
            {
                throw new ApplicationException($"An error occurred while saving the artist: {e.Message}");
            }

            return _mapper.Map<ArtistResource>(existingArtist);

        }
    }
    
    public class EditProfileHobbyistCommandHandler: IRequestHandler<EditProfileHobbyistCommand, HobbyistResource>
    {
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly IHobbyistRepository _hobbyistRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public EditProfileHobbyistCommandHandler(IPublisher publisher, IMapper mapper, IHobbyistRepository hobbyistRepository, IUnitOfWork unitOfWork)
        {
            _publisher = publisher;
            _mapper = mapper;
            _hobbyistRepository = hobbyistRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<HobbyistResource> Handle(EditProfileHobbyistCommand editProfileHobbyistCommand,
            CancellationToken cancellationToken)
        {
            var existingHobbyist =
                await _hobbyistRepository.GetHobbyistByIdAsync(editProfileHobbyistCommand.HobbyistId);

            if (existingHobbyist == null)
            {
                throw new ProfileNotFoundException("Profile not found");
            }

            _mapper.Map(editProfileHobbyistCommand, existingHobbyist);
            try
            {
                await _unitOfWork.CompleteAsync();

            }
            catch (Exception e)
            {
                throw new ApplicationException($"An error occurred while saving the artist: {e.Message}");
            }

            return _mapper.Map<HobbyistResource>(existingHobbyist);

        }
    }
   

}