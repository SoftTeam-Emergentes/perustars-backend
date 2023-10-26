using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.DataAnalytics.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PERUSTARS.DataAnalytics.Infrastructure
{
    public class DataAnalyticsProcessor
    {
        private AppDbContext _appDbContext;
        public DataAnalyticsProcessor(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<MLTrainingData> ProcessData()
        {
            IQueryable<MLTrainingData> processingQuery = from ArtistRecomendation in _appDbContext.ArtistRecommendations
                        join Participant in _appDbContext.EventAssistances on ArtistRecomendation.ArtistId equals Participant.ArtEvent.ArtistId
                        join Follower in _appDbContext.Followers on Participant.ArtEvent.ArtistId equals Follower.ArtistId
                        where ArtistRecomendation.Collected == false || Participant.ArtEvent.Collected == false || Follower.Collected == false
                        group new { ArtistRecomendation, Participant, Follower } by ArtistRecomendation.ArtistId into grupo
                        select new MLTrainingData
                        {
                            ArtistRecommendationArtistId = grupo.Key,
                            ArtistRecommendationHobbyistId = grupo.Select(item => item.ArtistRecomendation.HobyistId).ToList().First()
                        };
            return processingQuery.ToList();
        }
    }
}
