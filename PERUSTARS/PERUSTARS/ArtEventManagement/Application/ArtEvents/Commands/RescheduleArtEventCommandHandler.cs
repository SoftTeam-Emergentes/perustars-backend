using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.ArtEventManagement.Domain.Model.Commads;
using PERUSTARS.ArtEventManagement.Domain.Model.domainevents;
using PERUSTARS.ArtEventManagement.Domain.Model.Repositories;
using PERUSTARS.ArtEventManagement.Domain.Model.ValueObjects;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtEventManagement.Application.ArtEvents.Commands
{
    public class RescheduleArtEventCommandHandler : IRequestHandler<RescheduleArtEventCommand, string>
    {
        private readonly IArtEventRepository _artEventRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublisher _publisher;
        public RescheduleArtEventCommandHandler(IArtEventRepository artEventRepository, IUnitOfWork unitOfWork, IPublisher publisher)
        {
            _artEventRepository = artEventRepository;
            _unitOfWork = unitOfWork;
            _publisher = publisher;
        }
        public async Task<string> Handle(RescheduleArtEventCommand request, CancellationToken cancellationToken)
        {
            ArtEvent artEvent = await _artEventRepository.FindByIdAsync(request.id);
            if (artEvent != null)
            {
                artEvent.StartDateTime = request.newDate;
                artEvent.CurrentStatus = ArtEventStatus.RESCHEDULED;
                _artEventRepository.Update(artEvent);
                await _unitOfWork.CompleteAsync();
                await _publisher.Publish(new ArtEventRescheduledEvent()
                {
                    Title = artEvent.Title,
                    Description = artEvent.Description,
                    CurrentStatus = ArtEventStatus.RESCHEDULED,
                    StartDate = (System.DateTime)artEvent.StartDateTime,
                    Location = artEvent.Location
                });
                return "Art Event rescheduled!!";
            }
            else {
                return "The art event with the given id doesn't exist";
            }
        }

    }
}
