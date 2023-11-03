using System;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using PERUSTARS.Test.Infrastructure.Configuration;
using PERUSTARS.ArtworkManagement.Domain.Repositories;
using PERUSTARS.ArtworkManagement.Domain.Model.Commands;
using PERUSTARS.ArtworkManagement.Domain.Model.ValueObjects;
using PERUSTARS.ArtworkManagement.Application.Commands.Handlers;
using PERUSTARS.ArtworkManagement.Interfaces.REST.Resources;
using PERUSTARS.ArtworkManagement.Domain.Model.Enums;
using System.Threading.Tasks;

namespace PERUSTARS.Test.ArtworkManagement.UnitTests
{
    [TestFixture]
    public class ArtworkManagementUnitTests
    {
        private MockDbContext _context;
        private IArtworkRepository _artworkRepository;
        private UploadArtworkCommandHandler _uploadArtworkCommandHandler;
        private IServiceProvider serviceProvider;
        private IServiceScope scope;

        [SetUp]
        public async Task Setup()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IArtworkRepository, IArtworkRepository>();
            serviceCollection.AddTransient<UploadArtworkCommandHandler>();
            serviceProvider = serviceCollection.BuildServiceProvider();
            scope = serviceProvider.GetService<IServiceScope>();
            var exampleUploadCommand = new UploadArtworkCommand
            {
                Title = "El grito",
                Description = "Una obra de arte muy famosa",
                MainContent = new ArtworkContent
                {
                    Content = new byte[] { 0, 1, 2, 3, 4 },
                    Format = "png"
                },
                Price = 100,
                CoverImage = new ArtworkContent
                {
                    Content = new byte[] { 0, 1, 2, 3, 4 },
                    Format = "jpg"
                },
                ArtistId = 1
            };
            await _uploadArtworkCommandHandler.Handle(exampleUploadCommand, default);
        }

        [TearDown]
        public void TearDown()
        {
            // Libere los recursos cuando se completa la prueba
            scope.Dispose();
        }

        [Test]
        public async Task UploadArtworkTest()
        {
            var exampleArtworkResource = new ArtworkResource
            {
                Title = "El grito",
                Description = "Una obra de arte muy famosa",
                MainContent = new ArtworkContent
                {
                    Content = new byte[] { 0, 1, 2, 3, 4 },
                    Format = "png"
                },
                Price = 100,
                CoverImage = new ArtworkContent
                {
                    Content = new byte[] { 0, 1, 2, 3, 4 },
                    Format = "jpg"
                },
                PublishedAt = DateTime.Now,
                Status = ArtworkStatus.AVAILABLE,
                ArtistId = 1
            };

            var uploadCommand = new UploadArtworkCommand
            {
                Title = "El grito",
                Description = "Una obra de arte muy famosa",
                MainContent = new ArtworkContent
                {
                    Content = new byte[] { 0, 1, 2, 3, 4 },
                    Format = "png"
                },
                Price = 100,
                CoverImage = new ArtworkContent
                {
                    Content = new byte[] { 0, 1, 2, 3, 4 },
                    Format = "jpg"
                },
                ArtistId = 1
            };

            var artworkResource = await _uploadArtworkCommandHandler.Handle(uploadCommand, default);
            Assert.Equals(exampleArtworkResource, artworkResource);
        }
    }
}
