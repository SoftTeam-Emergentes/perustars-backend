using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtworkManagement.Domain.Model.Events;

namespace PERUSTARS.ArtworkManagement.Application.Events.Handlers
{
    public class ArtworkEditedEventHandler : INotificationHandler<ArtworkEditedEvent>
    {
        public ArtworkEditedEventHandler()
        {
        }

        public async Task Handle(ArtworkEditedEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
