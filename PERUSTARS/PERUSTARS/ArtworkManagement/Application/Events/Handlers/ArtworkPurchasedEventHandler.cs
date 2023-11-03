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

        public Task Handle(ArtworkPurchasedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
