using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtEventManagement.Domain.Model.domainevents;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Services;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtEventManagement.Application.artevents.events
{
    public class CancelledArtEventEventHandler : INotificationHandler<ArtEventCancelledEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationCommandService _notificationCommandService;
        public CancelledArtEventEventHandler(INotificationCommandService notificationCommandService, IUnitOfWork unitOfWork)
        {
            _notificationCommandService = notificationCommandService;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ArtEventCancelledEvent notification, CancellationToken cancellationToken)
        {
            NotifyArtEventCancelledCommand notifyArtEventCancelledCommand = new NotifyArtEventCancelledCommand();
            notifyArtEventCancelledCommand.Title = notification.Title;
            notifyArtEventCancelledCommand.Description= notification.Description;
            notifyArtEventCancelledCommand.Location = notification.Location;
            notifyArtEventCancelledCommand.EndDate = notification.EndDate;
            notifyArtEventCancelledCommand.CurrentStatus = notification.CurrentStatus;
            notifyArtEventCancelledCommand.StartDate = notification.StartDate;
            await _notificationCommandService.ExecuteNotifyArtEventCancelledCommand(notifyArtEventCancelledCommand);
        }
    }
}
