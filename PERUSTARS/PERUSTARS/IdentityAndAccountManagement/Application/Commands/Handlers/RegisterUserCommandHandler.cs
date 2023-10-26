using AutoMapper;
using MediatR;
using PERUSTARS.IdentityAndAccountManagement.Domain.Repositories;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Commands;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Events;
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;
using PERUSTARS.IdentityAndAccountManagement.Application.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;
using BCryptNet = BCrypt.Net.BCrypt;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.IdentityAndAccountManagement.Application.Commands.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserResource>
    {
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserCommandHandler(IPublisher publisher, IMapper mapper, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _publisher = publisher;
            _mapper = mapper;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserResource> Handle(RegisterUserCommand registerUserCommand, CancellationToken cancellationToken)
        {
            // TODO: Registrar Usuario como sabemos hacerlo
            UserResource userResource = new UserResource();
            if (_userRepository.ExistsByEmail(registerUserCommand.Email))
                throw new AppException($"Email '{registerUserCommand.Email}' is already taken.");

            var user = _mapper.Map<User>(registerUserCommand);

            user.PasswordHash = BCryptNet.HashPassword(registerUserCommand.Password);

            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while saving the user: {e.Message}");
            }
            // Realizar algún mapeo
            UserRegisteredEvent userRegisteredEvent = new UserRegisteredEvent()
            {
                UserId = user.UserId
            };
            await _publisher.Publish(userRegisteredEvent);
            return userResource;
        }
    }
}
