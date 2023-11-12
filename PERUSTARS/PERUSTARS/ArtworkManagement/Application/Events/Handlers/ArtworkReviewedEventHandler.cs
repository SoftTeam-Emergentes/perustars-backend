using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PERUSTARS.ArtworkManagement.Domain.Model.Events;
using PERUSTARS.ArtworkManagement.Domain.Repositories;
using PERUSTARS.DataAnalytics.Interface.ACL;
using PERUSTARS.DataAnalytics.Interface.ACL.Resources;

namespace PERUSTARS.ArtworkManagement.Application.Events.Handlers
{
    public class ArtworkReviewedEventHandler : INotificationHandler<ArtworkReviewedEvent>
    {
        private readonly DataAnalyticsFacade _dataAnalyticsFacade;
        private readonly IArtworkRepository _artworkRepository;
        private readonly ILogger<ArtworkReviewedEventHandler> _logger;
        public ArtworkReviewedEventHandler(DataAnalyticsFacade dataAnalyticsFacade, 
            IArtworkRepository artworkRepository, 
            ILogger<ArtworkReviewedEventHandler> logger)
        {
            _dataAnalyticsFacade = dataAnalyticsFacade;
            _artworkRepository = artworkRepository;
            _logger = logger;
        }

        public async Task Handle(ArtworkReviewedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("----Executing ArtworkReviewedEvent-----");
            var artwork = await _artworkRepository.FindByIdAsync(notification.ArtworkId);
            _logger.LogInformation("Command preparing to execute");
            await _dataAnalyticsFacade.ExecuteCollectArtworkReviewDataCommand(new DataAnalyticACLResource()
            {
                ArtistId = artwork.ArtistId,
                HobbyistId = notification.HobbyistId,
                Score = (long) notification.Calification
            });
            _logger.LogInformation("----ArtworkReviewedEvent execution finished-------");
        }
    }
}
