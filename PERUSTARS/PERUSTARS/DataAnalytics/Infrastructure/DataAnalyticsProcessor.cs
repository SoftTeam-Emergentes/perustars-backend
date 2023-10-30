using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
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
            IEnumerable<MLTrainingData> trainingData = new List<MLTrainingData>();
            //var result = _appDbContext.ParticipantEventRegistrations
            //    .Join(_appDbContext.ArtistRecommendations);
            

            return trainingData;
        }
    }
}
