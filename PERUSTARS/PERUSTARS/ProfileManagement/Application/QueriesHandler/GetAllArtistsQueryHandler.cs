using MediatR;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Queries;
using PERUSTARS.ProfileManagement.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.ProfileManagement.Application.QueriesHandler
{
    public class GetAllArtistsQueryHandler : IRequestHandler<GetAllArtistsQuery, IEnumerable<Artist>>
    {
        private readonly IArtistRepository _artistRepository;

        public GetAllArtistsQueryHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<IEnumerable<Artist>> Handle(GetAllArtistsQuery request, CancellationToken cancellationToken)
        {
            return await _artistRepository.GetAllArtists();
        }
    }
}
