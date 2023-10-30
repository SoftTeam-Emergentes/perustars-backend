using Microsoft.EntityFrameworkCore;
using PERUSTARS.ConductsReportsManagement.Domain.Model.Entities;
using PERUSTARS.ConductsReportsManagement.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.Shared.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.ConductsReportsManagement.Infrastructure.Repository
{
    public class ConductReportRepository : BaseRepository<ConductReport>, IConductReportRepository
    {
        public ConductReportRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<ConductReport>> ListByHobbystIdAsync(long hobbystId)
        {
            return await _dbContext.ConductReports
                .Where(c => c.HobbystId == hobbystId)
                .ToListAsync();
        }

        public new async Task AddAsync(ConductReport conductReport)
        {
            await _dbContext.ConductReports.AddAsync(conductReport);
            await _dbContext.SaveChangesAsync();
        }

        public Task<ConductReport> GetConductReportByIdAsync(long id)
        {
            try
            {
                return _dbContext.ConductReports.SingleOrDefaultAsync(c => c.id == id);
            }
            catch (Exception e)
            {
                throw new Exception("Error getting conduct report by id", e);
            }
        }

        public async Task<bool> DeleteConductReportAsync(ConductReport report)
        {
            try
            {
                if (report != null)
                {
                    _dbContext.ConductReports.Remove(report);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error deleting report", e);
            }
        }

        public bool ExistByTitle(string title)
        {
            return _dbContext.ConductReports.Any(c => c.Title == title);
        }
    }
}
