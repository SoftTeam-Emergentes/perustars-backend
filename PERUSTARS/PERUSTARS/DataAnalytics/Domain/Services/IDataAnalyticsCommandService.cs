using PERUSTARS.DataAnalytics.Domain.Model.Commands;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Domain.Services
{
    public interface IDataAnalyticsCommandService
    {
        Task<bool> ExecuteCollectArtworkReviewDataCommand(CollectArtworkReviewDataCommand collectArtworkReviewDataCommand);
        Task<bool> ExecuteCollectEventLogDataCommand(CollectEventLogDataCommand collectEventLogDataCommand);
        Task<bool> ExecuteCollectFollowedArtistDataCommand(CollectFollowedArtistDataCommand collectFollowedArtistDataCommand);
        Task<bool> ExecuteCollectPenaltyAppliedDataCommand(CollectPenaltyAppliedDataCommand collectPenaltyAppliedDataCommand);
    }
}
