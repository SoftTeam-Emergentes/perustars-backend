﻿using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.DataAnalytics.Domain.Repositories;
using PERUSTARS.Shared.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.Shared.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Infrastructure.Repositories
{
    public class MLTrainingDataRepository : BaseRepository<MLTrainingData>, IMLTrainingDataRepository
    {
        public MLTrainingDataRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task AddAllTrainingData(IEnumerable<MLTrainingData> entities)
        {
            await _dbContext.TrainingData.AddRangeAsync(entities);
        }
    }
}
