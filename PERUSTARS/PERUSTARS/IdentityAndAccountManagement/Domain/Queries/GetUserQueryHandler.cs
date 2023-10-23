using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.IdentityAndAccountManagement.Domain.Repositories;

namespace PERUSTARS.IdentityAndAccountManagement.Domain.Queries;

public class GetUserQueryHandler: IRequestHandler<GetUserQuery, GetUserQueryResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserQueryResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(request.UserId);
        return new GetUserQueryResponse
        {
            UserId = user.UserId,
            FirstName = user.FirstName
        };
    }
}