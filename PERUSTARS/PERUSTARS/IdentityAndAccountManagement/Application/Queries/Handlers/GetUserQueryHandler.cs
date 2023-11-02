using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Queries;
using PERUSTARS.IdentityAndAccountManagement.Domain.Repositories;
using PERUSTARS.IdentityAndAccountManagement.Interfaces.REST.Resources;

namespace PERUSTARS.IdentityAndAccountManagement.Application.Queries.Handlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserResource>
    {
        private readonly IUserRepository _userRepository;


        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResource> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByIdAsync(request.UserId.Value);
            return new UserResource
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }
    }
}

