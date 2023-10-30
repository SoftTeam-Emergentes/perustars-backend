using PERUSTARS.ConductsReportsManagement.Domain.Model.Entities;
using PERUSTARS.Shared.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.ConductsReportsManagement.Domain.Repositories
{
    public interface IConductReportRepository : IBaseRepository<ConductReport>
    {
        Task<IEnumerable<ConductReport>> ListByHobbystIdAsync(long hobbystId);
        Task<ConductReport> GetConductReportByIdAsync(long id);
        Task<bool> DeleteConductReportAsync(ConductReport report);
        bool ExistByTitle(string title);
    }
}
