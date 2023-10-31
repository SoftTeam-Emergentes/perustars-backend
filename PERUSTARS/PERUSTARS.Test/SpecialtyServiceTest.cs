using NUnit.Framework;
using Moq;
using FluentAssertions;
using System.Threading.Tasks;
using PERUSTARS.PastProject.Domain.Models;
using PERUSTARS.PastProject.Domain.Persistence.Repositories;
using PERUSTARS.PastProject.Domain.Services.Communications;
using PERUSTARS.PastProject.Services;

namespace PERUSTARS.Test
{
    class SpecialtyServiceTest
    {
        [SetUp]
        public void Setup(){}

        [Test]
        public async Task GetByIdAsyncWhenValidSpecialtyReturnsSpecialty()
        {
            // Arrange
            var mockSpecialtyRepository = GetDefaultISpecialtyRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var specialtyId = 1;
            Specialty specialty = new Specialty();
            specialty.Id = specialtyId;
            mockSpecialtyRepository.Setup(r => r.FindById(specialtyId))
                .Returns(Task.FromResult(specialty));

            var service = new SpecialtyService(mockSpecialtyRepository.Object, mockUnitOfWork.Object);

            // Act
            SpecialtyResponse result = await service.GetByIdAsync(specialtyId);
            var specialtyResult = result.Resource;
            // Assert
            specialtyResult.Should().Be(specialty);
        }
        [Test]
        public async Task GetByIdAsyncWhenNoSpecialtyReturnsSpecialtyNotFoundResponse()
        {
            // Arrange
            var mockSpecialtyRepository = GetDefaultISpecialtyRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var specialtyId = 1;
            mockSpecialtyRepository.Setup(r => r.FindById(specialtyId))
                .Returns(Task.FromResult<Specialty>(null));

            var service = new SpecialtyService(mockSpecialtyRepository.Object, mockUnitOfWork.Object);

            // Act
            SpecialtyResponse result = await service.GetByIdAsync(specialtyId);
            var message = result.Message;
            // Assert
            message.Should().Be("Specialty not found");
        }
        private Mock<ISpecialtyRepository> GetDefaultISpecialtyRepositoryInstance()
        {
            return new Mock<ISpecialtyRepository>();
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
