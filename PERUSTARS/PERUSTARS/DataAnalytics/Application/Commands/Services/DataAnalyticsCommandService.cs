using MediatR;
using PERUSTARS.ArtworkManagement.Domain.Model.Entities;
using PERUSTARS.DataAnalytics.Domain.Model.Commands;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.DataAnalytics.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Application.Commands.Services
{
    public class DataAnalyticsCommandService : IDataAnalyticsCommandService
    {
        private IMediator _mediator;
        public DataAnalyticsCommandService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<MLTrainingData> RetrieveTrainingDataToML()
        {
            CollectEventLogDataCommand collectEventLogDataCommand = new CollectEventLogDataCommand();
            CollectRecommendedArtworkDataCommand collectRecommendedArtworkDataCommand = new CollectRecommendedArtworkDataCommand();

            IEnumerable<ParticipantEventRegistration> eventLogDataDataCollection = await _mediator.Send(collectEventLogDataCommand);
            IEnumerable<ArtworkRecommendation> artworkRecommendationsData = await _mediator.Send(collectRecommendedArtworkDataCommand);

            return new MLTrainingData();
        }
    }
}
