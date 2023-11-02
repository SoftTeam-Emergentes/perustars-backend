﻿using System;
using System.Threading.Tasks;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands;
using PERUSTARS.CommunicationAndNotificationManagement.Interfaces.REST.Resources;

namespace PERUSTARS.CommunicationAndNotificationManagement.Domain.Services
{
    public interface INotificationCommandService
    {
        Task<bool> ExecuteNotifyUpdateArtistProfileCommand(NotifyUpdatedArtistProfileCommand updateArtistProfileCommand);    
        Task<bool> ExecuteNotifyNewArtworkCreatedCommand(NotifyNewArtworkCreatedCommand newArtworkCreatedCommand);
        Task<bool> ExecuteNotifyArtworkSoldCommand(NotifyArtworkSoldCommand artworkSoldCommand);
        Task<bool> ExecuteNotifyFollowedArtistCommand(NotifyFollowedArtistCommand followedArtistCommand);
        Task<bool> ExecuteNotifyAppliedPenaltyCommand(NotifyAppliedPenaltyCommand appliedPenaltyCommand);
        Task<bool> ExecuteNotifyArtEventCancelledCommand(NotifyArtEventCancelledCommand artEventCancelledCommand);
        Task<bool> ExecuteNotifyArtEventFinishedCommand(NotifyArtEventFinishedCommand artEventCreatedCommand);
        Task<bool> ExecuteNotifyArtEventSharedCommand(NotifyArtEventStartedCommand artEventCreatedCommand);
        Task<bool> ExecuteNotifyArtEventRescheduledCommand(NotifyArtEventRescheduledCommand artEventUpdatedCommand);

        Task<NotificationResource> ListNotificationsReceivedBydArtistIdAsync(long artistId);
        Task<NotificationResource> ListNotificationsReceivedByHobbyistIdAsync(long hobbyistId);
    }
}