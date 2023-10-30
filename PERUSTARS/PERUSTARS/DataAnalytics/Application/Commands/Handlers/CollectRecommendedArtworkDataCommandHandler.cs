using AutoMapper;
using MediatR;
using PERUSTARS.DataAnalytics.Domain.Model.Commands;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Application.Commands.Handlers
{
    public class CollectRecommendedArtworkDataCommandHandler : IRequestHandler<CollectRecommendedArtworkDataCommand, IEnumerable<ArtistArtworkRecommendation>>
    {
        private readonly IPublisher _publisher;

        public CollectRecommendedArtworkDataCommandHandler(IPublisher publisher)
        {
            _publisher = publisher;
        }

        public async Task<IEnumerable<ArtistArtworkRecommendation>> Handle(CollectRecommendedArtworkDataCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new List<ArtistArtworkRecommendation>());
        }
    }
}
