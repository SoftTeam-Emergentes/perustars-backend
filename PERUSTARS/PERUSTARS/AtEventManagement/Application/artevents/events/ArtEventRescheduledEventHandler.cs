using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.domainevents;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Services;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Application.artevents.events
{
    public class ArtEventRescheduledEventHandler : INotificationHandler<ArtEventRescheduledEvent>
    {
        private readonly INotificationCommandService _notificationCommandService;
        public ArtEventRescheduledEventHandler(INotificationCommandService notificationCommandService)
        {
            _notificationCommandService = notificationCommandService;
        }
        public async Task Handle(ArtEventRescheduledEvent notification, CancellationToken cancellationToken)
        {
            NotifyArtEventRescheduledCommand notifyArtEventRescheduledCommand = new NotifyArtEventRescheduledCommand();
            notifyArtEventRescheduledCommand.Title = notification.Title;
            notifyArtEventRescheduledCommand.Description = notification.Description;
            notifyArtEventRescheduledCommand.Location = notification.Location;
            notifyArtEventRescheduledCommand.StartDate = notification.StartDate;
            notifyArtEventRescheduledCommand.CurrentStatus = notification.CurrentStatus;
            await _notificationCommandService.ExecuteNotifyArtEventRescheduledCommand(notifyArtEventRescheduledCommand);
        }
    }
}
