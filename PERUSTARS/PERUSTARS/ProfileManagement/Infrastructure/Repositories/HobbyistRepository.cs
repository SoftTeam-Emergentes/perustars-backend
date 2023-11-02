using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.Shared.Infrastructure.Repositories;

namespace PERUSTARS.ProfileManagement.Infrastructure.Repositories
{
    public class HobbyistRepository:BaseRepository<Hobbyist>,IHobbyistRepository
    {
        public HobbyistRepository(AppDbContext dbContext):base(dbContext){}
        
        public Task<Hobbyist> GetHobbyistByIdAsync(long hobbyistId)
        {
            try
            {
                return _dbContext.Hobbyists.SingleOrDefaultAsync(a => a.HobbyistId == hobbyistId);
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error getting hobbyist by id",ex);
            }
        }
        
        public async Task<bool> DeleteHobbyistProfileAsync( Hobbyist hobbyist)
        {
            try
            {
                if (hobbyist != null)
                {
                    _dbContext.Hobbyists.Remove(hobbyist);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error deleting hobbyist profile",e);
            }
        }
        
    }
}