using AutoMapper;
using MediatR;
using Moq;
using NUnit.Framework;
using PERUSTARS.ConductsReportsManagement.Application.Command.Handlers;
using PERUSTARS.ConductsReportsManagement.Domain.Model.Commands;
using PERUSTARS.ConductsReportsManagement.Domain.Repositories;
using PERUSTARS.Shared.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERUSTARS.Test.ConductReportManagement.UnitTests
{
    [TestFixture]
    class ConductReportManagementUnitTest
    {
        [Test]
        public async Task RegisterConductReport()
        {
            var registerConductReportCommand = new RegisterConductReportCommand
            {
                Id = 1,
                Title = "Offensive Picture",
                Description = "It's a offensive pictures & discriminate to other persons",
                DateTimeReport = DateTime.Now,
                HobbystId = 2
            };

            var conductReportRepositoryMock = new Mock<IConductReportRepository>();

            conductReportRepositoryMock.Setup(repo => repo.ExistByTitle(registerConductReportCommand.Title))
                .Returns(false);

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var publisherMock = new Mock<IPublisher>();
            var mapperMock = new Mock<IMapper>();

            var handler = new RegisterConductReportCommandHandler(
                mapperMock.Object,
                conductReportRepositoryMock.Object,
                unitOfWorkMock.Object
                );

            var conductReportResource = await handler.Handle(registerConductReportCommand, default);
            Assert.Equals(registerConductReportCommand, conductReportResource);
        }
    }
}
