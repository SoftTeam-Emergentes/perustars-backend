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

        public async Task Handle(ArtworkReviewedEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
