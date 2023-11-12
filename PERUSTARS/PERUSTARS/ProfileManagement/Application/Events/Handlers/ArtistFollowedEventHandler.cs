using MediatR;
using PERUSTARS.DataAnalytics.Interface.ACL;
using PERUSTARS.DataAnalytics.Interface.ACL.Resources;
using PERUSTARS.ProfileManagement.Domain.Model.Events;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.ProfileManagement.Application.Events.Handlers
{
    public class ArtistFollowedEventHandler : INotificationHandler<ArtistFollowedEvent>
    {
        private readonly DataAnalyticsFacade _dataAnalyticsFacade;

        public ArtistFollowedEventHandler(DataAnalyticsFacade dataAnalyticsFacade)
        {
            _dataAnalyticsFacade = dataAnalyticsFacade;
        }

        public async Task Handle(ArtistFollowedEvent notification, CancellationToken cancellationToken)
        {
            await _dataAnalyticsFacade.ExecuteCollectFollowedArtistDataCommand(new DataAnalyticACLResource()
            {
                ArtistId = notification.ArtistId,
                HobbyistId = notification.HobbyistId,
            });
        }
    }
}
