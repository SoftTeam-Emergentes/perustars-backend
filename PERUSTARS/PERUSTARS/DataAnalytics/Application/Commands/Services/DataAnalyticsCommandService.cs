using MediatR;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.DataAnalytics.Domain.Repositories;
using PERUSTARS.DataAnalytics.Domain.Services;
using PERUSTARS.DataAnalytics.Infrastructure;
using PERUSTARS.Shared.Infrastructure.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Application.Commands.Services
{
    public class DataAnalyticsCommandService : IDataAnalyticsCommandService
    {
        private readonly IMLTrainingDataRepository _mLTrainingDataRepository;
        public DataAnalyticsCommandService(IMLTrainingDataRepository mLTrainingDataRepository)
        {
            _mLTrainingDataRepository = mLTrainingDataRepository;
        }

        public async Task<IEnumerable<MLTrainingData>> RetrieveTrainingDataToML()
        {
            return await _mLTrainingDataRepository.GetAllNotProccessedTrainingDataAsync();
        }
    }
}
