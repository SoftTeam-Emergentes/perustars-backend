using MediatR;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Queries;
using PERUSTARS.ProfileManagement.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.ProfileManagement.Application.QueriesHandler
{
    public class GetAllFollowersByArtistQueryHandler : IRequestHandler<GetAllFollowersByArtistQuery, IEnumerable<Follower>>
    {
        private readonly IFollowerRepository _followerRepository;

        public GetAllFollowersByArtistQueryHandler(IFollowerRepository followerRepository)
        {
            _followerRepository = followerRepository;
        }

        public async Task<IEnumerable<Follower>> Handle(GetAllFollowersByArtistQuery query, CancellationToken cancellationToken)
        {
            return await _followerRepository.GetFollowerByArtistIdAsync(query.ArtistId);
        }
    }
}
