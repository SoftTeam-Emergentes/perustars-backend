using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtworkManagement.Domain.Model.Events;

namespace PERUSTARS.ArtworkManagement.Application.Events.Handlers
{
    public class ArtworkDeletedEventHandler : INotificationHandler<ArtworkDeletedEvent>
    {
        public ArtworkDeletedEventHandler()
        {
        }

        public Task Handle(ArtworkDeletedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
