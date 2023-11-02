using MediatR;
using System.Threading.Tasks;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;

namespace PERUSTARS.ArtworkManagement.Domain.Services
{
    public interface IHobbyistFavoriteArtworkCommandService
    {
        Task<Unit> ExecuteAssignFavoriteArtworkCommand(AssignFavoriteArtworkCommand assignFavoriteArtworkCommand);
    }
}