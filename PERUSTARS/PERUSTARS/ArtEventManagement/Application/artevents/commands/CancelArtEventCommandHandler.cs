using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.ArtEventManagement.Domain.Model.Commads;
using PERUSTARS.ArtEventManagement.Domain.Model.domainevents;
using PERUSTARS.ArtEventManagement.Domain.Model.Repositories;
using PERUSTARS.ArtEventManagement.Domain.Model.ValueObjects;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtEventManagement.Application.artevents.commands
{
    public class CancelArtEventCommandHandler : IRequestHandler<CancelArtEventCommand,string>
    {
        private readonly IArtEventRepository _artEventRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublisher _publisher;
        public CancelArtEventCommandHandler(IMediator mediator, IArtEventRepository artEventRepository, IUnitOfWork unitOfWork,IPublisher publisher)
        {
            _artEventRepository = artEventRepository;
            _unitOfWork = unitOfWork;
            _publisher = publisher;

        }
        public async Task<string> Handle(CancelArtEventCommand request, CancellationToken cancellationToken)
        {
            ArtEvent artEvent = _artEventRepository.FindByIdAsync(request.id).Result;
            if (artEvent != null)
            {
               
                    artEvent.CurrentStatus = ArtEventStatus.CANCELLED;
                    _artEventRepository.Update(artEvent);
                    await _publisher.Publish(new ArtEventCancelledEvent()
                    {
                        Title = artEvent.Title,
                        Description = artEvent.Description,
                        Location = artEvent.Location,
                        EndDate = DateTime.Now,
                        CurrentStatus = ArtEventStatus.CANCELLED,
                        StartDate = (DateTime)artEvent.StartDateTime
                    });
                    await _unitOfWork.CompleteAsync();
                    return "Event updated!!!";
               
            }
            else {
                return "The event with the given id doesn't exist";
            }
        }
    }
}
