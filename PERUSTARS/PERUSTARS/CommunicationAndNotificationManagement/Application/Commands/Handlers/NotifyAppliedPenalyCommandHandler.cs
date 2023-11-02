using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Commands;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Entities;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Enums;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Model.Events;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Repositories;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.CommunicationAndNotificationManagement.Application.Commands.Handlers
{
    public class NotifyAppliedPenaltyCommandHandler : IRequestHandler<NotifyAppliedPenaltyCommand,bool>
    {
        public readonly IPublisher _publisher;
        private readonly IMapper _mapper;
        private readonly INotificationRepository _notificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NotifyAppliedPenaltyCommandHandler(IPublisher publisher, IMapper mapper, INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
        {
            _publisher = publisher;
            _mapper = mapper;
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(NotifyAppliedPenaltyCommand request, CancellationToken cancellationToken)
        {
            var notification = _mapper.Map<Notification>(request);
            notification.Title = "Recibiste una penalidad";
            notification.Description = "Has recibido una penalidad por no cumplir con los términos y condiciones de la plataforma";
            notification.Sender = NotificationSender.ARTIST;
            notification.SentAt = DateTime.UtcNow;

            try
            {   
                await _notificationRepository.AddAsync(notification);
                await _unitOfWork.CompleteAsync();

                await _publisher.Publish(new PenaltyAppliedNotifiedEvent());

            }
            catch (Exception e)
            {
                throw new ApplicationException($"An error occurred while notifying the penalty that has been applied: {e.Message}");
            }
            


            return await Task.FromResult(true);
            
        }



    } 
}
