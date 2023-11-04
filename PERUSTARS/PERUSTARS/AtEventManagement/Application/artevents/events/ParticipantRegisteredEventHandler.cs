using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.domainevents;
using PERUSTARS.DataAnalytics.Interface.ACL;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Application.artevents.events
{
    public class ParticipantRegisteredEventHandler : INotificationHandler<ParticipantRegisteredEvent>
    {
        private readonly DataAnalyticsFacade _dataAnalyticsFacade;

        public ParticipantRegisteredEventHandler(DataAnalyticsFacade dataAnalyticsFacade)
        {
            _dataAnalyticsFacade = dataAnalyticsFacade;
        }

        public async Task Handle(ParticipantRegisteredEvent notification, CancellationToken cancellationToken)
        {
            await _dataAnalyticsFacade.ExecuteCollectEventLogDataCommand(new DataAnalytics.Interface.ACL.Resources.DataAnalyticACLResource()
            {
                ArtistId = notification.ArtistId,
                HobbyistId = notification.HobbyistId
            });
        }
    }
}
