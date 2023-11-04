using Microsoft.EntityFrameworkCore;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.DataAnalytics.Domain.Repositories;
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
        public async Task<IEnumerable<MLTrainingData>> GetAllNotProccessedTrainingDataAsync()
        {
            return await _dbContext.TrainingData
                .Where(ml => ml.Collected == false)
                .ToListAsync();
        }
    }
}
