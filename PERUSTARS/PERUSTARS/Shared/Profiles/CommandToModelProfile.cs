using System;
using AutoMapper;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Entities;

namespace PERUSTARS.Shared.Profiles
{
    public class CommandToModelProfile : Profile
    {
        public CommandToModelProfile()
        {
            CreateMap<NotifyUpdatedArtistProfileCommand, Notification>();
            CreateMap<NotifyNewArtworkCreatedCommand, Notification>();
            CreateMap<NotifyFollowedArtistCommand, Notification>();
            CreateMap<NotifyArtworkSoldCommand, Notification>();
            CreateMap<NotifyArtEventStartedCommand, Notification>();
            CreateMap<NotifyArtEventFinishedCommand, Notification>();
            CreateMap<NotifyArtEventCancelledCommand, Notification>();
            CreateMap<NotifyArtEventRescheduledCommand, Notification>();            
        }
    }
}
