using MediatR;
using System.Threading.Tasks;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;
using PERUSTARS.ArtworkManagement.Domain.Services;
using PERUSTARS.ArtworkManagement.Interfaces.REST.Resources;

namespace PERUSTARS.ArtworkManagement.Application.Commands.Services
{
    public class ArtworkCommandService : IArtworkCommandService
    {
        private readonly IMediator _mediator;

        public ArtworkCommandService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ArtworkResource> ExecuteUploadArtworkCommand(UploadArtworkCommand uploadArtworkCommand)
        {
            return await _mediator.Send(uploadArtworkCommand);
        }

        public async Task<ArtworkResource> ExecuteEditArtworkCommand(EditArtworkCommand editArtworkCommand)
        {
            return await _mediator.Send(editArtworkCommand);
        }

        public async Task<Unit> ExecuteDeleteArtwork(DeleteArtworkCommand deleteArtworkCommand)
        {
            return await _mediator.Send(deleteArtworkCommand);
        }

        public async Task<ArtworkResource> ExecutePurchaseArtworkCommand(PurchaseArtworkCommand purchaseArtworkCommand)
        {
            return await _mediator.Send(purchaseArtworkCommand);
        }
    }
}
