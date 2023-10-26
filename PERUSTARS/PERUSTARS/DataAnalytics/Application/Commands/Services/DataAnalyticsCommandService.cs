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
        private readonly IMediator _mediator;
        private readonly DataAnalyticsProcessor _dataAnalyticsProcessor;
        private readonly IMLTrainingDataRepository _mLTrainingDataRepository;
        public DataAnalyticsCommandService(IMediator mediator, AppDbContext dbContext,IMLTrainingDataRepository mLTrainingDataRepository)
        {
            _mediator = mediator;
            _dataAnalyticsProcessor = new DataAnalyticsProcessor(dbContext);
            _mLTrainingDataRepository = mLTrainingDataRepository;
        }

        public async Task<MLTrainingData> RetrieveTrainingDataToML()
        {

            return await Task.FromResult(new MLTrainingData());
        }

        public async Task SaveTrainingDataToDb()
        {
            IEnumerable<MLTrainingData> newTrainingData = _dataAnalyticsProcessor.ProcessData();
            await _mLTrainingDataRepository.AddAllTrainingData(newTrainingData);
        }
    }
}
