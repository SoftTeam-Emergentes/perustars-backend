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

        public async Task Handle(ArtworkRecommendedEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
