using MediatR;
using System.Threading.Tasks;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;
using PERUSTARS.ArtworkManagement.Interfaces.REST.Resources;

namespace PERUSTARS.ArtworkManagement.Domain.Services
{
    public interface IArtworkReviewCommandService
    {
        Task<ArtworkReviewResource> ExecuteReviewArtworkCommand(ReviewArtworkCommand reviewArtworkCommand);
    }
}
