using MediatR;
using PERUSTARS.ConductsReportsManagement.Domain.Model.Events;
using PERUSTARS.DataAnalytics.Interface.ACL;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.ConductsReportsManagement.Application.Events.Handlers
{
    public class ConductReportRegisteredEventHandler : INotificationHandler<ConductReportRegisteredEvent>
    {
        private readonly DataAnalyticsFacade _dataAnalyticsFacade;

        public ConductReportRegisteredEventHandler(DataAnalyticsFacade dataAnalyticsFacade)
        {
            _dataAnalyticsFacade = dataAnalyticsFacade;
        }

        public async Task Handle(ConductReportRegisteredEvent notification, CancellationToken cancellationToken)
        {
            await _dataAnalyticsFacade.ExecuteCollectPenaltyAppliedDataCommand(new DataAnalytics.Interface.ACL.Resources.DataAnalyticACLResource()
            {
                ArtistId = notification.ArtistId,
                HobbyistId = notification.HobbyistId
            });
        }
    }
}
