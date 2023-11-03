using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtworkManagement.Domain.Model.Events;

namespace PERUSTARS.ArtworkManagement.Application.Events.Handlers
{
    public class ArtworkReviewedEventHandler : INotificationHandler<ArtworkReviewedEvent>
    {
        public ArtworkReviewedEventHandler()
        {
        }

        public Task Handle(ArtworkReviewedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
