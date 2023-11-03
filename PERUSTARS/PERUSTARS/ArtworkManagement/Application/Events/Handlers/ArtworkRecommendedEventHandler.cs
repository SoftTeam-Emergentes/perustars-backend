using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtworkManagement.Domain.Model.Events;

namespace PERUSTARS.ArtworkManagement.Application.Events.Handlers
{
    public class ArtworkRecommendedEventHandler : INotificationHandler<ArtworkRecommendedEvent>
    {
        public ArtworkRecommendedEventHandler()
        {
        }

        public Task Handle(ArtworkRecommendedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
