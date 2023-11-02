using System;
using System.Threading.Tasks;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands;
using PERUSTARS.CommunicationAndNotificationManagement.Interfaces.REST.Resources;

namespace PERUSTARS.CommunicationAndNotificationManagement.Domain.Services
{
    public interface INotificationCommandService
    {
        Task<NotificationResource> ExecuteNotifyUpdateArtistProfileCommand(NotifyUpdatedArtistProfileCommand updateArtistProfileCommand);    
        Task<NotificationResource> ExecuteNotifyNewArtworkCreatedCommand(NotifyNewArtworkCreatedCommand newArtworkCreatedCommand);
        Task<NotificationResource> ExecuteNotifyArtworkSoldCommand(NotifyArtworkSoldCommand artworkSoldCommand);
        Task<NotificationResource> ExecuteNotifyFollowedArtistCommand(NotifyFollowedArtistCommand followedArtistCommand);
        Task<NotificationResource> ExecuteNotifyAppliedPenaltyCommand(NotifyAppliedPenaltyCommand appliedPenaltyCommand);
        Task<NotificationResource> ExecuteNotifyArtEventCancelledCommand(NotifyArtEventCancelledCommand artEventCancelledCommand);
        Task<NotificationResource> ExecuteNotifyArtEventFinishedCommand(NotifyArtEventFinishedCommand artEventCreatedCommand);
        Task<NotificationResource> ExecuteNotifyArtEventSharedCommand(NotifyArtEventStartedCommand artEventCreatedCommand);
        Task<NotificationResource> ExecuteNotifyArtEventRescheduledCommand(NotifyArtEventRescheduledCommand artEventUpdatedCommand);

        Task<NotificationResource> ListNotificationsReceivedBydArtistIdAsync(long artistId);
        Task<NotificationResource> ListNotificationsReceivedByHobbyistIdAsync(long hobbyistId);
    }
}
