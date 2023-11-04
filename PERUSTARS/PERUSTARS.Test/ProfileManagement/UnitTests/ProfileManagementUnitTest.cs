using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Moq;
using NUnit.Framework;
using PERUSTARS.ProfileManagement.Application.Commands.Handlers;
using PERUSTARS.ProfileManagement.Domain.Model.Commands;
using PERUSTARS.ProfileManagement.Domain.Model.Enum;
using PERUSTARS.ProfileManagement.Domain.Repositories;
using PERUSTARS.Shared.Domain.Repositories;


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
}