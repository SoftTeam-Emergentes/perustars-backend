using System.Collections.Generic;
using System.Threading.Tasks;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Entities;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Enums;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.CommunicationAndNotificationManagement.Domain.Repositories
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
        Task<IEnumerable<Notification>> FindbySenderAndArtistIdAsync(NotificationSender senderType, long artistId);
        Task<IEnumerable<Notification>> FindbySenderAndHobbyistIdAsync(NotificationSender senderType,long hobbyistId);
        Task AddAsync(Notification notification);
        void Remove(Notification notification);

        

    }
}
