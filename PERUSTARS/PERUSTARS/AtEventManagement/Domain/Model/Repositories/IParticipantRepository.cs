﻿using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.Shared.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Domain.Model.Repositories
{
    public interface IParticipantRepository:IBaseRepository<Participant>
    {
        Task<IEnumerable<Participant>> findByArtEventIdAsync(long artEventId);
        Task<IEnumerable<Participant>> findByHobystIdAsync(long  hobystId);
    }
}
