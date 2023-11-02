using System;
using AutoMapper;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands;
using PERUSTARS.CommunicationAndNotificationManagement.Interfaces.REST.Resources;

namespace PERUSTARS
{
    public class ResourceToCommandProfile : Profile
    {
        public ResourceToCommandProfile()
        {
            CreateMap<NotificationResource, NotifyUpdatedArtistProfileCommand>();
            CreateMap<NotificationResource, NotifyNewArtworkCreatedCommand>();
            CreateMap<NotificationResource, NotifyFollowedArtistCommand>();
            CreateMap<NotificationResource, NotifyArtworkSoldCommand>();
            CreateMap<NotificationResource, NotifyArtEventStartedCommand>();
            CreateMap<NotificationResource, NotifyArtEventFinishedCommand>();
            CreateMap<NotificationResource, NotifyArtEventCancelledCommand>();
            CreateMap<NotificationResource, NotifyArtEventRescheduledCommand>();
        }
    }
}
