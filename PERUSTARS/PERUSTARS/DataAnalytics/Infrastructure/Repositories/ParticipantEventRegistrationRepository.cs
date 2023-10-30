using Microsoft.EntityFrameworkCore;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.DataAnalytics.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.Shared.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Infrastructure.Repositories
{
    public class ParticipantEventRegistrationRepository : BaseRepository<ParticipantEventRegistration>, IParticipantEventRegistrationRepository
    {
        public ParticipantEventRegistrationRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ParticipantEventRegistration>> GetAllNotCollectedParticipantEventRegistrationsAsync()
        {
            return await _dbContext.ParticipantEventRegistrations
                .Where(p => p.Collected == false)
                .ToListAsync();
        }
    }
}
