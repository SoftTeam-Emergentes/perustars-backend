using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PERUSTARS.IdentityAndAccountManagement.Application.Exceptions;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Commands;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Events;
using PERUSTARS.IdentityAndAccountManagement.Domain.Repositories;
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;
using PERUSTARS.Shared.Domain.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;

namespace PERUSTARS.IdentityAndAccountManagement.Application.Commands.Handlers
{
    public class LogInUserCommandHandler : IRequestHandler<LogInUserCommand, AuthenticateResponse>
    {
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRequestHandler<GenerateJwtTokenCommand, string> _generateJwtTokenHandler; // Agregar la inyección de dependencia
        private readonly ILogger<LogInUserCommandHandler> _logger;

        public LogInUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, 
            IMapper mapper, IPublisher publisher, 
            IRequestHandler<GenerateJwtTokenCommand, string> generateJwtTokenHandler,
            ILogger<LogInUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _publisher = publisher;
            _generateJwtTokenHandler = generateJwtTokenHandler;
            _logger = logger;
        }

        public async Task<AuthenticateResponse> Handle(LogInUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByEmailAsync(request.Email);
            //Console.WriteLine($"Request: {request.Email}, {request.Password}");
            //Console.WriteLine($"User: {user.Id}, {user.Name}, {user.LastName}, {user.PasswordHash}");

            if (user == null || !BCryptNet.Verify(request.Password, user.PasswordHash))
            {
                _logger.LogError("Authentication Error");
                return new AuthenticateResponse
                {
                    Token = null,
                    Message = "Username or password is incorrect."
                };
            }
            var generateTokenCommand = new GenerateJwtTokenCommand { User = user };
            var jwtToken = await _generateJwtTokenHandler.Handle(generateTokenCommand, cancellationToken);

            var response = new AuthenticateResponse { 
                Token = jwtToken,
                Message = "User logged in successfully"
            };
            UserLoggedInEvent userLoggedInEvent = new UserLoggedInEvent();
            await _publisher.Publish(userLoggedInEvent);
            return response;
        }
    }
}

