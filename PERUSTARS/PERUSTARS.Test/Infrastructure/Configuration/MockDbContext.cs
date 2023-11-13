using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;
using PERUSTARS.Shared.Infrastructure.Configuration;

namespace PERUSTARS.Test.Infrastructure.Configuration
{
    public class MockDbContext
    {
        private readonly Mock<AppDbContext> _mockDbContext;
        public MockDbContext()
        {
            _mockDbContext = new Mock<AppDbContext>();
            var fakeUserDbSet = ConfigureFakeDbSet(new List<User>() { });
            _mockDbContext.Setup(c => c.Users).Returns(fakeUserDbSet.Object);
            
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

        public AppDbContext GetDbContext()
        {
            return _mockDbContext.Object;
        }
    }
}