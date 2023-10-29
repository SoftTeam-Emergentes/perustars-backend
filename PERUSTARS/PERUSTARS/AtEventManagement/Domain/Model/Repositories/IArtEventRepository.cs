﻿using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.Shared.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Domain.Model.Repositories
{
    public interface IArtEventRepository:IBaseRepository<ArtEvent>
    {
        Task<IEnumerable<ArtEvent>> findByArtistIdAsync(int artistId);
        Task<IEnumerable<ArtEvent>> findByHobbyistIdAsync(int hobbyistId);
    }
}