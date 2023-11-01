using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtworkManagement.Domain.Model.Events;

namespace PERUSTARS.ArtworkManagement.Application.Events.Handlers
{
    public class ArtworkPurchasedEventHandler : INotificationHandler<ArtworkPurchasedEvent>
    {
        public ArtworkPurchasedEventHandler()
        {
        }

        public async Task Handle(ArtworkPurchasedEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
