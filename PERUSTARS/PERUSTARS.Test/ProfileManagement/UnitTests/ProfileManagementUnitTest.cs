using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using NUnit.Framework;
using PERUSTARS.ProfileManagement.Application.Commands.Handlers;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Domain.Model.Enum;
using PERUSTARS.ProfileManagement.Domain.Repositories;
using PERUSTARS.Shared.Domain.Repositories;
using PERUSTARS.Test.Infrastructure.Configuration;


namespace PERUSTARS.Test.ProfileManagement.UnitTests
{
    [TestFixture]
    public class ProfileManagementUnitTest
    {
        [Test]
        public async Task RegisterArtist()
        {
            var registerProfileArtistCommand = new RegisterProfileArtistCommand
            {
                BrandName = "ArtistName",
                Description = "short description of the artist",
                Phrase="artist's phrase",
                ContactNumber = 977785472,
                ContactEmail = "artist@hotmail.com",
                Age=30,
                Genre = Genre.MUSICIAN,
                SocialMediaLink = {"fb,instagram"}
                
            };

            var artistRepositoryMock = new Mock<IArtistRepository>();
            artistRepositoryMock.Setup(repo => repo.ExistsByBrandName(registerProfileArtistCommand.BrandName))
                .Returns(false);

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var publisherMock = new Mock<IPublisher>();
            var mapperMock = new Mock<IMapper>();

            var handler = new RegisterProfileArtistCommandHandler(
                publisherMock.Object,
                mapperMock.Object,
                artistRepositoryMock.Object,
                unitOfWorkMock.Object
            );

            
            var artistResource = await handler.Handle(registerProfileArtistCommand, default);
            Assert.Equals(registerProfileArtistCommand, artistResource);
            
            
        }

    }
  
    [TestFixture]
    public class ArtistCreationAndEditingIntegrationTest
    {
        private WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private MockDbContext _mockDbContext; 

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
           
            _mockDbContext = new MockDbContext();

            _factory = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                
                builder.ConfigureTestServices(services =>
                {
                    services.RemoveAll(typeof(DbContext));
                    services.AddScoped(provider => _mockDbContext.GetDbContext());
                });
            });

            _client = _factory.CreateClient();
        }

        [Test]
        public async Task CrearYEditarArtista_ConMockDbContext_IntegracionExitosa()
        {
            var createArtistCommand = new RegisterProfileArtistCommand()
            {
                BrandName = "Artista de Prueba",
                Description = "short description of the artist",
                Phrase="artist's phrase",
                ContactNumber = 977785472,
                ContactEmail = "artist@hotmail.com",
                Age=30,
                Genre = Genre.MUSICIAN,
                SocialMediaLink = {"fb,instagram"}
                
            };

            var createRequestContent = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(createArtistCommand),
                Encoding.UTF8,
                "application/json"
            );

          
            var createResponse = await _client.PostAsync("/api/artist/create", createRequestContent);

            
            createResponse.EnsureSuccessStatusCode();

            var responseContent = await createResponse.Content.ReadAsStringAsync();
            var createdArtist = System.Text.Json.JsonSerializer.Deserialize<Artist>(responseContent);
            var artistId = createdArtist.ArtistId;
            
            
            var editArtistCommand = new EditProfileArtistCommand()
            {
                ArtistId = 1,
                BrandName = "Artista Editado",
                Description = "short description of the artist",
                Phrase="artist's phrase",
                ContactNumber = 977785472,
                ContactEmail = "artist@hotmail.com",
                Age=30,
                Genre = Genre.Filmmaker,
                SocialMediaLink = {"fb,instagram"}
            };

            var editRequestContent = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(editArtistCommand),
                Encoding.UTF8,
                "application/json"
            );

            
            var editResponse = await _client.PutAsync($"/api/artist/edit/{artistId}", editRequestContent);
            editResponse.EnsureSuccessStatusCode();
        }
    }
}