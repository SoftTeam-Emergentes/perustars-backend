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
    }
    
}