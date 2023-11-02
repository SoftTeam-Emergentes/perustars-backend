using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Aggregates;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Queries;
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;


namespace PERUSTARS.IdentityAndAccountManagement.Application.Queries.Handlers
{
    public class ValidateTokenAndRetrieveUserHandler : IRequestHandler<ValidateTokenAndRetrieveUserQuery, User>
    {
        private readonly IRequestHandler<GetUserQuery, UserResource> _getUserQueryHandler;
        private readonly IRequestHandler<ValidateJwtTokenQuery, long?> _validateJwtTokenQueryHandler;
        private readonly IMapper _mapper;

        public ValidateTokenAndRetrieveUserHandler(IRequestHandler<GetUserQuery, UserResource> getUserQueryHandler, IMapper mapper, IRequestHandler<ValidateJwtTokenQuery, long?> validateJwtTokenQueryHandler)
        {
            _getUserQueryHandler = getUserQueryHandler;
            _mapper = mapper;
            _validateJwtTokenQueryHandler = validateJwtTokenQueryHandler;
        }

        public async Task<User> Handle(ValidateTokenAndRetrieveUserQuery request, CancellationToken cancellationToken)
        {
            var validateJwtTokenQuery = new ValidateJwtTokenQuery { Token = request.Token };
            var userId = await _validateJwtTokenQueryHandler.Handle(validateJwtTokenQuery, cancellationToken);
            if (userId.HasValue)
            {
                //return await _userService.GetByIdAsync(userId.Value);
                var getUserQuery = new GetUserQuery { UserId = userId };
                var userResource = await _getUserQueryHandler.Handle(getUserQuery, cancellationToken);
                var user = _mapper.Map<UserResource, User>(userResource);
                return user;
            }

            return null;
        }
    }
}


