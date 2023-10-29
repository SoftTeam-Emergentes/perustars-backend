using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Domain.Services;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;

namespace PERUSTARS.ProfileManagement.Application.Commands.Services
{
    public class ProfileCommandService : IProfileCommandService
    {
        private readonly IMediator _mediator;

        public ProfileCommandService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ArtistResource> ExecuteRegisterProfileCommand(RegisterProfileArtistCommand artistProfileCommand)
        {
            return await _mediator.Send(artistProfileCommand);
        }

        public async Task<HobbyistResource> ExecuteRegisterProfileCommand(RegisterProfileHobbyistCommand hobbyistProfileCommand)
        {
            return await _mediator.Send(hobbyistProfileCommand);
        }

        public async Task<Unit> ExecuteDeleteProfileCommand(DeleteProfileArtistCommand deleteProfileArtistCommand)
        {
            return await _mediator.Send(deleteProfileArtistCommand);

        }

        public async Task<Unit> ExecuteDeleteProfileCommand(DeleteProfileHobbyistCommand deleteProfileHobbyistCommand)
        {
            return await _mediator.Send(deleteProfileHobbyistCommand);
        }

        public async Task<HobbyistResource> ExecuteEditProfileCommand(EditProfileHobbyistCommand editProfileHobbyistCommand)
        {
            return await _mediator.Send(editProfileHobbyistCommand);
        }

        public async Task<ArtistResource> ExecuteEditProfileCommand(EditProfileArtistCommand editProfileArtistCommand)
        {
            return await _mediator.Send(editProfileArtistCommand);
        }

        public async Task<Unit> ExecuteFollowArtistCommand(FollowArtistCommand followArtistCommand)
        {
            return await _mediator.Send(followArtistCommand);
        }
    }
    
}