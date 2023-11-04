using MediatR;
using PERUSTARS.DataAnalytics.Domain.Model.Commands;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.DataAnalytics.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Application.Commands.Services
{
    public class DataAnalyticsCommandService : IDataAnalyticsCommandService
    {
        private readonly IMediator _mediator;
        
        public DataAnalyticsCommandService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> ExecuteCollectArtworkReviewDataCommand(CollectArtworkReviewDataCommand collectArtworkReviewDataCommand)
        {
            return await _mediator.Send(collectArtworkReviewDataCommand);
        }

        public async Task<bool> ExecuteCollectEventLogDataCommand(CollectEventLogDataCommand collectEventLogDataCommand)
        {
            return await _mediator.Send(collectEventLogDataCommand);
        }

        public async Task<bool> ExecuteCollectFollowedArtistDataCommand(CollectFollowedArtistDataCommand collectFollowedArtistDataCommand)
        {
            return await _mediator.Send(collectFollowedArtistDataCommand);
        }

        public async Task<bool> ExecuteCollectPenaltyAppliedDataCommand(CollectPenaltyAppliedDataCommand collectPenaltyAppliedDataCommand)
        {
            return await _mediator.Send(collectPenaltyAppliedDataCommand);
        }
    }
}
