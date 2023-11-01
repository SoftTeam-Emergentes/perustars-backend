using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;
using PERUSTARS.ArtworkManagement.Domain.Services;
using PERUSTARS.ArtworkManagement.Interfaces.REST.Resources;

namespace PERUSTARS.ArtworkManagement.Application.Commands.Services
{
    public class ArtworkRecommendationCommandService : IArtworkRecommendationCommandService
    {
        private readonly IMediator _mediator;

        public ArtworkRecommendationCommandService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ArtworkRecommendationResource> ExecuteRecommendArtworkCommand(RecommendArtworkCommand recommendArtworkCommand)
        {
            return await _mediator.Send(recommendArtworkCommand);
        }
    }
}
