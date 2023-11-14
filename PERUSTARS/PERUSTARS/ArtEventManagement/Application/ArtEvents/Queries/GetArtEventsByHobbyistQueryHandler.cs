using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtEventManagement.Domain.Model.Queries;
using PERUSTARS.ArtEventManagement.Domain.Model.Repositories;
using PERUSTARS.ArtEventManagement.Interfaces.REST.Resources;
using PERUSTARS.ProfileManagement.Domain.Repositories;

namespace PERUSTARS.ArtEventManagement.Application.ArtEvents.Queries;

public class GetArtEventsByHobbyistQueryHandler: IRequestHandler<GetArtEventsByHobbyistQuery, IEnumerable<ArtEventResource>>
{
    private readonly IArtEventRepository _artEventRepository;
    private readonly IParticipantRepository _participantRepository;
    private readonly IHobbyistRepository _hobbyistRepository;
    
    public Task<IEnumerable<ArtEventResource>> Handle(GetArtEventsByHobbyistQuery request, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }
}