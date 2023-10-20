using PERUSTARS.DataAnalytics.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.Shared.Infrastructure.Repositories;

namespace PERUSTARS.DataAnalytics.Infrastructure.Repositories
{
    public class ParticipanteEventRegistrationRepository
    {
        public ParticipanteEventRegistrationRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}
