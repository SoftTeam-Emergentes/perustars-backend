using System.Threading.Tasks;
using NUnit.Framework;
using PERUSTARS.IdentityAndAccountManagement.Application.Commands.Handlers;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Commands;
using PERUSTARS.IdentityAndAccountManagement.Domain.Repositories;
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;
using PERUSTARS.Test.Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace PERUSTARS.Test.IdentityAndAccountManagement.UnitTests
{
    [TestFixture]
    public class IdentityAndAccountManagementUnitTests
    {
        private MockDbContext _context;
        private IUserRepository _userRepository;
        private RegisterUserCommandHandler _registerUserCommandHandler;
        private LogInUserCommandHandler _logInUserCommandHandler;
        private IServiceProvider serviceProvider;
        private IServiceScope scope;

        [SetUp]
        public async Task Setup()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IUserRepository, IUserRepository>();
            serviceCollection.AddTransient<RegisterUserCommandHandler>();
            serviceCollection.AddTransient<LogInUserCommandHandler>();
            serviceProvider = serviceCollection.BuildServiceProvider();
            scope = serviceProvider.GetService<IServiceScope>();
            var exampleRegisterCom = new RegisterUserCommand
            {
                Email = "mau@mishisoft.com",
                FirstName = "Mauricio",
                LastName = "Prado",
                Password = "12345"
            };
            await _registerUserCommandHandler.Handle(exampleRegisterCom, default);
        }

        [TearDown]
        public void TearDown()
        {
            // Libere los recursos cuando se completa la prueba
            scope.Dispose();
        }

        [Test]
        public async Task LogInUserTest()
        {
            var exampleAuthResp = new AuthenticateResponse
            {
                UserId = 1,
                Email = "mau@mishisoft.com",
                FirstName = "Mauricio",
                LastName = "Prado"
            };
            var logInCommand = new LogInUserCommand
            {
                Email = "mau@mishisoft.com",
                Password = "12345"
            };
            var authResponse = await _logInUserCommandHandler.Handle(logInCommand, default);
            exampleAuthResp.Token = authResponse.Token;
            Assert.Equals(exampleAuthResp, authResponse);
        }
        [Test]
        public async Task RegisterUserTest()
        {
            var exampleUserRes = new UserResource 
            { 
                UserId = 2, 
                Email="messi@goat.com",
                FirstName="Lionel",
                LastName="Messi"
            };
            var registerUserCommand = new RegisterUserCommand 
            {
                Email = "messi@goat.com",
                FirstName = "Lionel",
                LastName = "Messi",
                Password = "12345"
            };
            var userResource = await _registerUserCommandHandler.Handle(registerUserCommand, default);
            Assert.Equals(exampleUserRes, userResource);
        }
    }
}