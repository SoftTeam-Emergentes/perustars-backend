using MediatR;
using System.Threading.Tasks;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;
using PERUSTARS.ArtworkManagement.Interfaces.REST.Resources;

namespace PERUSTARS.ArtworkManagement.Domain.Services
{
    public interface IArtworkCommandService
    {
        Task<ArtworkResource> ExecuteUploadArtworkCommand(UploadArtworkCommand uploadArtworkCommand);
        Task<ArtworkResource> ExecuteEditArtworkCommand(EditArtworkCommand editArtworkCommand);
        Task<Unit> ExecuteDeleteArtwork(DeleteArtworkCommand deleteArtworkCommand);
        Task<ArtworkResource> ExecutePurchaseArtworkCommand(PurchaseArtworkCommand purchaseArtworkCommand);
    }
}
