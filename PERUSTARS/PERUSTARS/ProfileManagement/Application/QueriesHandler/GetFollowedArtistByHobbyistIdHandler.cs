using MediatR;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Queries;
using PERUSTARS.ProfileManagement.Domain.Repositories;
using PERUSTARS.Shared.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.ProfileManagement.Application.QueriesHandler
{
    public class GetFollowedArtistByHobbyistIdHandler:IRequestHandler<GetFollowedArtistByHobbyistIdQuery,IEnumerable<Artist>>
    {
        private readonly IFollowerRepository _followerRepository;
        private readonly IUnitOfWork _unitOfWord;
        public GetFollowedArtistByHobbyistIdHandler(IFollowerRepository followerRepository, IUnitOfWork unitOfWord)
        {
            _followerRepository = followerRepository;
            _unitOfWord = unitOfWord;
        }

        public async Task<IEnumerable<Artist>> Handle(GetFollowedArtistByHobbyistIdQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Artist> response = await _followerRepository.findFollowedArtistByHobbyistId(request.HobbyistId);
            return response;
        }
    }
}
