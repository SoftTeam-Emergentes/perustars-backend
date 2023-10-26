using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Domain.Model.Services;
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

        public async Task<ArtistResource> executeRegisterProfileCommand(RegisterProfileArtistCommand artistProfileCommand)
        {
            return await _mediator.Send(artistProfileCommand);
        }

        public Task<HobbyistResource> executeRegisterProfileCommand(RegisterProfileHobbyistCommand hobbyistProfileCommand)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProfileResource> executeRegisterProfileCommand(RegisterProfileArtistCommand artistProfileCommand,
            RegisterProfileHobbyistCommand registerProfileHobbyistCommand)
        {
            throw new System.NotImplementedException();
        }
    }
    
}