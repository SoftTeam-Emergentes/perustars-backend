using System;
using System.Threading.Tasks;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands;
using PERUSTARS.CommunicationAndNotificationManagement.Interfaces.REST.Resources;

namespace PERUSTARS.CommunicationAndNotificationManagement.Domain.Services
{
    public interface INotificationCommandService
    {
        Task<NotificationResource> ExecuteNotifyUpdateArtistProfileCommand(NotifyUpdatedArtistProfileCommand updateArtistProfileCommand);    
    }
}
