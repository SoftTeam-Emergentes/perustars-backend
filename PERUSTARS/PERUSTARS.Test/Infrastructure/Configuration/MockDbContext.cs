using Microsoft.EntityFrameworkCore;
using Moq;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.Shared.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERUSTARS.Test.Infrastructure.Configuration
{
    public class MockDbContext
    {
        private readonly Mock<AppDbContext> _mockDbContext;
        public MockDbContext()
        {
            _mockDbContext = new Mock<AppDbContext>();
            var fakeMLDbSet = ConfigureFakeDbSet(new List<MLTrainingData>() { });
            _mockDbContext.Setup(c => c.TrainingData).Returns(fakeMLDbSet.Object);
            
        }
        private Mock<DbSet<T>> ConfigureFakeDbSet<T>(List<T> fakeData) where T: class
        {
            var fakeDbSet = new Mock<DbSet<T>>();
            fakeDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(fakeData.AsQueryable().Provider);
            fakeDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(fakeData.AsQueryable().Expression);
            fakeDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(fakeData.AsQueryable().ElementType);
            fakeDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(fakeData.AsQueryable().GetEnumerator());
            return fakeDbSet;
        }

        public AppDbContext getDbContext()
        {
            return _mockDbContext.Object;
        }
    }
}
