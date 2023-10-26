using AutoMapper;
using MediatR;
using PERUSTARS.DataAnalytics.Domain.Model.Commands;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.DataAnalytics.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Application.Commands.Handlers
{
    public class CollectRecommendedArtworkDataCommandHandler : IRequestHandler<CollectRecommendedArtworkDataCommand, IEnumerable<ArtistRecommendation>>
    {
        private readonly IPublisher _publisher;
        private readonly IArtistArtworkRecommendationRepository _artistArtworkRecommendationRepository;

        public CollectRecommendedArtworkDataCommandHandler(IPublisher publisher, IArtistArtworkRecommendationRepository artistArtworkRecommendationRepository)
        {
            _publisher = publisher;
            _artistArtworkRecommendationRepository = artistArtworkRecommendationRepository;
        }

        public async Task<IEnumerable<ArtistRecommendation>> Handle(CollectRecommendedArtworkDataCommand request, CancellationToken cancellationToken)
        {
            return await _artistArtworkRecommendationRepository.GetAllNotCollectedArtistRecommendationsAsync();
        }
    }
}
