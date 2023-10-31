using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;
using PERUSTARS.ArtworkManagement.Domain.Services;
using PERUSTARS.ArtworkManagement.Interfaces.REST.Resources;

namespace PERUSTARS.ArtworkManagement.Application.Commands.Services
{
    public class ArtworkReviewCommandService : IArtworkReviewCommandService
    {
        private readonly IMediator _mediator;

        public ArtworkReviewCommandService(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<ArtworkReviewResource> ExecuteReviewArtworkCommand(ReviewArtworkCommand reviewArtworkCommand)
        {
            return await _mediator.Send(reviewArtworkCommand);
        }
    }
}
