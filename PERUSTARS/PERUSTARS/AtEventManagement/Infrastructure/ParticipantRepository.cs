using Microsoft.EntityFrameworkCore;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.AtEventManagement.Domain.Model.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.Shared.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Infrastructure
{
    public class ParticipantRepository : BaseRepository<Participant>,IParticipantRepository
    {
        public ParticipantRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        //public new async Task AddAsync(Participant entity)
        //{
        //    await _dbContext.Participants.AddAsync(entity);
        //    await _dbContext.SaveChangesAsync();
        //
        //}
        //
        //public new async Task<Participant> FindByIdAsync(int id)
        //{
        //    return await _dbContext.Participants.FindAsync(id);
        //}
        //
        //public new async Task<IEnumerable<Participant>> ListAsync()
        //{
        //    return await _dbContext.Participants.ToListAsync();
        //}
        //
        //public new async void Remove(Participant entity)
        //{
        //    var participant=await _dbContext.Participants.FindAsync(entity);
        //    if (participant != null)
        //    {
        //        _dbContext.Participants.Remove(participant);
        //        await _dbContext.SaveChangesAsync();
        //    }
        //}
        //
        //public new async void Update(Participant entity)
        //{
        //    _dbContext.Participants.Update(entity);
        //    await _dbContext.SaveChangesAsync();
        //}

        public async Task<IEnumerable<Participant>> findByArtEventIdAsync(long artEventId)
        {
            return await _dbContext.Participants.Where(p=>p.ArtEventId == artEventId).ToListAsync();
        }

        public async Task<IEnumerable<Participant>> findByHobystIdAsync(long hobystId)
        {
            return await _dbContext.Participants.Where(p=>p.HobbyistId == hobystId).ToListAsync();
        }
    }
}
