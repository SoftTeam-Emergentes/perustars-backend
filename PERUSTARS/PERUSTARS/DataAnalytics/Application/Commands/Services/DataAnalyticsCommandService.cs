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
<<<<<<< HEAD
            IEnumerable<ArtistRecommendation> artworkRecommendationsData = await _mediator.Send(collectRecommendedArtworkDataCommand);
=======
            IEnumerable<ArtworkRecommendation> artworkRecommendationsData = await _mediator.Send(collectRecommendedArtworkDataCommand);
>>>>>>> 9558cddde4fa7558354244a9aaff9582135ab6db

            return new MLTrainingData();
        }
    }
}
