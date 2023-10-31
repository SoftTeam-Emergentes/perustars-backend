using MediatR;
using PERUSTARS.ArtworkManagement.Interfaces.REST.Resources;

namespace PERUSTARS.ArtworkManagement.Domain.Model.Commands
{
    public class PurchaseArtworkCommand : IRequest<ArtworkResource>
    {
        public long Id { get; set; }
    }
}
