using System;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Entities;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Enums;

namespace PERUSTARS.CommunicationAndNotificationManagement.Infraestructure.Repositories
{
    public class NotificationRepository :BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(AppDbContext dbcontext) : base(dbcontext)    
        {  
        }

        public async Task<IEnumerable<Notification>> FindbySenderAndArtistIdAsync(NotificationSender senderType, long artistId)
        {
            return await _dbContext.Set<Notification>()
                .Where(n => n.Sender == senderType && n.ArtistId == artistId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Notification>> FindbySenderAndHobbyistIdAsync(NotificationSender senderType, long hobbyistId)
        {
            return await _dbContext.Set<Notification>()
                .Where(n => n.Sender == senderType && n.HobbyistId == hobbyistId)
                .ToListAsync();
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
