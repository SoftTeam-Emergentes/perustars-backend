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
    class HobbyistServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task GetByIdAsyncWhenValidHobbyistReturnsHobbyist()
        {
            // Arrange
            var mockHobbyistRepository = GetDefaultIHobbyistRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockFollowerRepository = new Mock<IFollowerRepository>();
            var hobbyistId = 1;
            Hobbyist hobbyist = new Hobbyist();
            hobbyist.Id = hobbyistId;
            mockHobbyistRepository.Setup(r => r.FindById(hobbyistId))
                .Returns(Task.FromResult(hobbyist));

            var service = new HobbyistService(mockHobbyistRepository.Object, mockUnitOfWork.Object, mockFollowerRepository.Object);

            // Act
            HobbyistResponse result = await service.GetByIdAsync(hobbyistId);
            var artworkResult = result.Resource;
            // Assert
            artworkResult.Should().Be(hobbyist);
        }
        [Test]
        public async Task GetByIdAsyncWhenNoHobbyistReturnsHobbyistNotFoundResponse()
        {
            // Arrange
            var mockHobbyistRepository = GetDefaultIHobbyistRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockFollowerRepository = new Mock<IFollowerRepository>();
            var hobbyistId = 1;
            mockHobbyistRepository.Setup(r => r.FindById(hobbyistId))
                .Returns(Task.FromResult<Hobbyist>(null));

            var service = new HobbyistService(mockHobbyistRepository.Object, mockUnitOfWork.Object,mockFollowerRepository.Object);

            // Act
            HobbyistResponse result = await service.GetByIdAsync(hobbyistId);
            var message = result.Message;
            // Assert
            message.Should().Be("Hobbyist not found");
        }
        private Mock<IHobbyistRepository> GetDefaultIHobbyistRepositoryInstance()
        {
            return new Mock<IHobbyistRepository>();
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
