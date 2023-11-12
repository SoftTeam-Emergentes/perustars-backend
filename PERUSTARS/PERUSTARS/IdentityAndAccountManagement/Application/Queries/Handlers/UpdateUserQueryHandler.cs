using MediatR;
using Microsoft.Extensions.Logging;
using PERUSTARS.IdentityAndAccountManagement.Application.Exceptions;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Queries;
using PERUSTARS.IdentityAndAccountManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.IdentityAndAccountManagement.Application.Queries.Handlers
{
    public class UpdateUserQueryHandler : IRequestHandler<UpdateUserQuery, KeyValuePair<string, long>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateUserQueryHandler> _logger;

        public UpdateUserQueryHandler(IUserRepository userRepository, ILogger<UpdateUserQueryHandler> logger, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<KeyValuePair<string, long>> Handle(UpdateUserQuery query, CancellationToken cancellationToken)
        {
            User existingUser = await _userRepository.FindByIdAsync(query.UserId);
            if (existingUser == null)
                return new KeyValuePair<string, long>($"User with Id {query.UserId} does not exist", 400);

            _logger.LogInformation("Updating User Info");
            existingUser.FirstName = query.FirstName;
            existingUser.LastName = query.LastName;

            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();
            }
            catch(Exception exception)
            {
                _logger.LogError("An error occured while trying to update an user");
                _logger.LogError("Error message: {}", exception.Message);
                _logger.LogError("Detailed error message: {}", exception.InnerException.Message);
                throw new AppException(exception.Message);
            }
            return new KeyValuePair<string, long>("User successfully updated",200);
        }
    }
}
