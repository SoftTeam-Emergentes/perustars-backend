using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Model.Queries;
using PERUSTARS.ProfileManagement.Domain.Repositories;
using PERUSTARS.ProfileManagement.Interface.REST.Resources;

namespace PERUSTARS.ProfileManagement.Application.QueriesHandler;

public class GetArtistByIdHandler: IRequestHandler<GetArtistByIdQuery,GetArtistFollowers>
{
    private readonly IArtistRepository _artistRepository;

    public GetArtistByIdHandler(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
        
    }

    public async Task<GetArtistFollowers> Handle(GetArtistByIdQuery query, CancellationToken cancellationToken)
    {
        var artist = await _artistRepository.GetArtistByIdAsync(query.ArtistId);
        return new GetArtistFollowers
        {
            ArtistId = artist.ArtistId,
            UserId = artist.UserId,
            FollowersArtist = artist.FollowersArtist
        };
    }
}