using System;
using System.Threading.Tasks;
using PERUSTARS.CommunicationAndNotificationManagement.Interfaces.REST.Resources;

namespace PERUSTARS.CommunicationAndNotificationManagement.Domain.Services
{
    public interface INotificationSenderService
    {
        Task<NotificationResource> ListNotificationsBydArtistIdAsync(long artistId);
        Task<NotificationResource> ListNotificationsByHobbyistIdAsync(long hobbyistId);
    }
}
