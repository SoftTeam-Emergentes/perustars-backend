using System.Collections.Generic;
using MediatR;
using PERUSTARS.ArtEventManagement.Interfaces.REST.Resources;

namespace PERUSTARS.ArtEventManagement.Domain.Model.Queries;

public class GetArtEventsByHobbyistQuery: IRequest<IEnumerable<ArtEventResource>>
{
    public long HobbyistId { get; set; }
}