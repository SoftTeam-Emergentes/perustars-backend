using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PERUSTARS.ConductsReportsManagement.Domain.Model.Entities;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ConductsReportsManagement.Domain.Repositories
{
    public interface IConductReportRepository : IBaseRepository<ConductReport>
    {
        Task<IEnumerable<ConductReport>> ListByHobbyIdAsync();

        Task AddAsync();
        Task AddPenalty();
        ConductReport FindById(long id);
    }
}
