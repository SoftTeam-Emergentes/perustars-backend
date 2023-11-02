using NUnit.Framework;
using PERUSTARS.DataAnalytics.Application.Commands.Handlers;
using PERUSTARS.DataAnalytics.Domain.Repositories;
using PERUSTARS.DataAnalytics.Domain.Model.Commands;
using PERUSTARS.DataAnalytics.Infrastructure.Repositories;
using PERUSTARS.Test.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PERUSTARS.DataAnalytics.Application.Commands;

namespace PERUSTARS.Test.DataAnalytics.UnitTests
{
    public class DataAnalyticsUnitTests
    {
        private readonly MockDbContext _context;
        private readonly IMLTrainingDataRepository _mLTrainingDataRepository;
        private readonly CollectEventLogDataCommandHandler _handler;
        public DataAnalyticsUnitTests()
        {
            _context = new MockDbContext();
            _mLTrainingDataRepository = new MLTrainingDataRepository(_context.getDbContext());
            _handler = new CollectEventLogDataCommandHandler(_mLTrainingDataRepository);
        }

        [Test]
        public async void CollectEventLogDataTest()
        {
            bool result = await _handler.Handle(new CollectEventLogDataCommand()
            {
                ArtistId = 1,
                HobbyistId = 2,
                InteractionType = PERUSTARS.DataAnalytics.Domain.Model.Enums.InteractionType.EVENT_PARTICIPATION,
                Score = 3,
            }, default);
            Assert.IsTrue(result);
        }
    }
}
