using System;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Entities;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PERUSTARS.CommunicationAndNotificationManagement.Infraestructure.Repositories
{
    public class NotificationRepository :BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(AppDbContext dbcontext) : base(dbcontext)    
        {  
        }

        public async Task<IEnumerable<Notification>> ListByArtistIdAsync(long artistId)
        {
            return await _dbContext.Notifications.Where(n => n.ArtistId == artistId).ToListAsync();
        }

        public async Task<IEnumerable<Notification>> ListByHobbyistIdAsync(long hobbyistId)
        {
            return await _dbContext.Notifications.Where(n => n.HobbyistId == hobbyistId).ToListAsync();
        }

        public async Task AddAsync(Notification notification)
        {
            await _dbContext.Notifications.AddAsync(notification);
        }

        public void Remove(Notification notification)
        {
            _dbContext.Notifications.Remove(notification);
        }

        
    }
}
