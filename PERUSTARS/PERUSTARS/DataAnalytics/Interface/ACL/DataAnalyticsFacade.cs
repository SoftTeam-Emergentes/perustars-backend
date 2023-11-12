using AutoMapper;
using PERUSTARS.DataAnalytics.Domain.Model.Commands;
using PERUSTARS.DataAnalytics.Domain.Services;
using PERUSTARS.DataAnalytics.Interface.ACL.Resources;
using PERUSTARS.DataAnalytics.Domain.Model.Enums;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Interface.ACL
{
    public class DataAnalyticsFacade
    {
        private readonly IDataAnalyticsCommandService _dataAnalyticsCommandService;
        private readonly IMapper _mapper;

        public DataAnalyticsFacade(IDataAnalyticsCommandService dataAnalyticsCommandService, IMapper mapper)
        {
            _dataAnalyticsCommandService = dataAnalyticsCommandService;
            _mapper = mapper;
        }

        public async Task<bool> ExecuteCollectArtworkReviewDataCommand(DataAnalyticACLResource dataAnalyticACLResource)
        {
            CollectArtworkReviewDataCommand collectArtworkReviewDataCommand = _mapper.Map<CollectArtworkReviewDataCommand>(dataAnalyticACLResource);
            collectArtworkReviewDataCommand.InteractionType = InteractionType.ARTWORK_REVIEW;
            return await _dataAnalyticsCommandService.ExecuteCollectArtworkReviewDataCommand(collectArtworkReviewDataCommand);
        }

        public async Task<bool> ExecuteCollectEventLogDataCommand(DataAnalyticACLResource dataAnalyticACLResource)
        {
            CollectEventLogDataCommand collectEventLogDataCommand = _mapper.Map<CollectEventLogDataCommand>(dataAnalyticACLResource);
            collectEventLogDataCommand.Score = 4;
            collectEventLogDataCommand.InteractionType = InteractionType.EVENT_PARTICIPATION;
            return await _dataAnalyticsCommandService.ExecuteCollectEventLogDataCommand(collectEventLogDataCommand);
        }

        public async Task<bool> ExecuteCollectFollowedArtistDataCommand(DataAnalyticACLResource dataAnalyticACLResource)
        {
            CollectFollowedArtistDataCommand collectFollowedArtistDataCommand = _mapper.Map<CollectFollowedArtistDataCommand>(dataAnalyticACLResource);
            collectFollowedArtistDataCommand.Score = 2;
            collectFollowedArtistDataCommand.InteractionType = InteractionType.FOLLOW;
            return await _dataAnalyticsCommandService.ExecuteCollectFollowedArtistDataCommand(collectFollowedArtistDataCommand);
        }

        public async Task<bool> ExecuteCollectPenaltyAppliedDataCommand(DataAnalyticACLResource dataAnalyticACLResource)
        {
            CollectPenaltyAppliedDataCommand collectPenaltyAppliedDataCommand = _mapper.Map<CollectPenaltyAppliedDataCommand>(dataAnalyticACLResource);
            collectPenaltyAppliedDataCommand.Score = -2;
            collectPenaltyAppliedDataCommand.InteractionType = InteractionType.CONDUCT_REPORT;
            return await _dataAnalyticsCommandService.ExecuteCollectPenaltyAppliedDataCommand(collectPenaltyAppliedDataCommand);
        }

    }
}
