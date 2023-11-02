using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PERUSTARS.IdentityAndAccountManagement.Application.Exceptions;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Domain.Model.Events;
using PERUSTARS.ProfileManagement.Domain.Repositories;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ProfileManagement.Application.Commands.Handlers
{
    public class RegisterProfileArtistCommandHandler : IRequestHandler<RegisterProfileArtistCommand, ArtistResource>
    {

        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly IArtistRepository _artistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterProfileArtistCommandHandler(IPublisher publisher, IMapper mapper, IArtistRepository artistRepository, IUnitOfWork unitOfWork)
        {
            _publisher = publisher;
            _mapper = mapper;
            _artistRepository = artistRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<ArtistResource> Handle(RegisterProfileArtistCommand registerProfileArtistCommand,
            CancellationToken cancellationToken)
        {
            //TO-DO



            if (_artistRepository.ExistsByBrandName(registerProfileArtistCommand.BrandName))
                throw new AppException($"BrandName '{registerProfileArtistCommand.BrandName}' is already taken.");


            var artist = _mapper.Map<RegisterProfileArtistCommand, Artist>(registerProfileArtistCommand);


            try
            {
                await _artistRepository.AddAsync(artist);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {

                throw new AppException($"An error occurred while saving the artist: {e.Message}");
            }

            ProfileRegisteredEvent profileRegisteredEvent = new ProfileRegisteredEvent()
            {
                ArtistId = artist.ArtistId
            };

            await _publisher.Publish(profileRegisteredEvent);
            var artistResource = _mapper.Map<Artist, ArtistResource>(artist);
            return artistResource;
        }


    }

    public class RegisterProfileHobbyistCommandHandler : IRequestHandler<RegisterProfileHobbyistCommand, HobbyistResource>
    {
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly IHobbyistRepository _hobbyistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterProfileHobbyistCommandHandler(IPublisher publisher, IMapper mapper, IHobbyistRepository hobbyistRepository, IUnitOfWork unitOfWork)
        {
            _publisher = publisher;
            _mapper = mapper;
            _hobbyistRepository = hobbyistRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<HobbyistResource> Handle(RegisterProfileHobbyistCommand registerProfileHobbyistCommand,
            CancellationToken cancellationToken)
        {
            var hobbyist = _mapper.Map<RegisterProfileHobbyistCommand, Hobbyist>(registerProfileHobbyistCommand);
            try
            {
                await _hobbyistRepository.AddAsync(hobbyist);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new ApplicationException($"An error occurred while saving the hobbyist: {e.Message}");
            }

            ProfileRegisteredEvent profileRegisteredEvent = new ProfileRegisteredEvent()
            {
                HobbyistId = hobbyist.HobbyistId
            };

            await _publisher.Publish(profileRegisteredEvent);
            var hobbyistResource = _mapper.Map<Hobbyist, HobbyistResource>(hobbyist);
            return hobbyistResource;
        }

    }
}