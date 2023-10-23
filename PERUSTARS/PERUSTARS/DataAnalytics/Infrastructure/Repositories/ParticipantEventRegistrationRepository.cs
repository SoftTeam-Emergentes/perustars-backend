using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.DataAnalytics.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.Shared.Infrastructure.Repositories;

namespace PERUSTARS.DataAnalytics.Infrastructure.Repositories
{
    public class ParticipantEventRegistrationRepository : BaseRepository<ParticipantEventRegistration>, IParticipantEventRegistrationRepository
    {
        public ParticipantEventRegistrationRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
