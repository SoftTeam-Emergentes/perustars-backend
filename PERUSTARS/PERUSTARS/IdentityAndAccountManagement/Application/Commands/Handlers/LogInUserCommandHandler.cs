using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PERUSTARS.IdentityAndAccountManagement.Application.Exceptions;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Commands;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Events;
using PERUSTARS.IdentityAndAccountManagement.Domain.Repositories;
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;
using PERUSTARS.Shared.Domain.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;

namespace PERUSTARS.IdentityAndAccountManagement.Application.Commands.Handlers;

public class LogInUserCommandHandler: IRequestHandler<LogInUserCommand, AuthenticateResponse>
{
    private readonly IPublisher _publisher;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IRequestHandler<GenerateJwtTokenCommand, string> _generateJwtTokenHandler; // Agregar la inyección de dependencia

    public LogInUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IPublisher publisher, IRequestHandler<GenerateJwtTokenCommand, string> generateJwtTokenHandler)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _publisher = publisher;
        _generateJwtTokenHandler = generateJwtTokenHandler;
    }

    public async Task<AuthenticateResponse> Handle(LogInUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByEmailAsync(request.Email);
        //Console.WriteLine($"Request: {request.Email}, {request.Password}");
        //Console.WriteLine($"User: {user.Id}, {user.Name}, {user.LastName}, {user.PasswordHash}");

        if (user == null || !BCryptNet.Verify(request.Password, user.PasswordHash))
        {
            Console.WriteLine("Authentication Error");
            throw new AppException("Username or password is incorrect.");
        }
        var generateTokenCommand = new GenerateJwtTokenCommand { User = user };
        var jwtToken = await _generateJwtTokenHandler.Handle(generateTokenCommand, cancellationToken);
        
        var response = _mapper.Map<AuthenticateResponse>(user);
        response.Token = jwtToken;
        UserLoggedInEvent userLoggedInEvent = new UserLoggedInEvent
        {
            UserId = response.UserId
        };
        await _publisher.Publish(userLoggedInEvent);
        return response;
    }
}