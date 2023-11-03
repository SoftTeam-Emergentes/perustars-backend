using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtworkManagement.Domain.Model.Events;

namespace PERUSTARS.ArtworkManagement.Application.Events.Handlers
{
    public class ArtworkUploadedEventHandler : INotificationHandler<ArtworkUploadedEvent>
    {
        public ArtworkUploadedEventHandler()
        {
        }

        public Task Handle(ArtworkUploadedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
