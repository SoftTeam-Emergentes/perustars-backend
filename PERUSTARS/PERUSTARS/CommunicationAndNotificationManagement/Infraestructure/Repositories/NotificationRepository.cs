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
      
        
    }
}
