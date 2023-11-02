using MediatR;
using System.Threading.Tasks;
using PERUSTARS.ArtworkManagement.Domain.Services;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;

namespace PERUSTARS.ArtworkManagement.Application.Commands.Services
{
    public class HobbyistFavoriteArtworkCommandService : IHobbyistFavoriteArtworkCommandService
    {
        private readonly IMediator _mediator;

        public HobbyistFavoriteArtworkCommandService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> ExecuteAssignFavoriteArtworkCommand(AssignFavoriteArtworkCommand assignFavoriteArtworkCommand)
        {
            return await _mediator.Send(assignFavoriteArtworkCommand);
        }
    }
}