﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.ArtEventManagement.Domain.Model.Commads;
using PERUSTARS.ArtEventManagement.Domain.Model.domainevents;
using PERUSTARS.ArtEventManagement.Domain.Model.Repositories;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.ProfileManagement.Domain.Repositories;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtEventManagement.Application.ArtEvents.Commands
{
    public class RegisterParticipantToArtEventCommandHandler : IRequestHandler<RegisterParticipantToArtEventCommand, string>
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly IHobbyistRepository _hobbyistRepository;
        private readonly IArtEventRepository _artEventRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublisher _publisher;
        public RegisterParticipantToArtEventCommandHandler(IParticipantRepository participantRepository, IHobbyistRepository hobbyistRepository,
            IArtEventRepository artEventRepository, IUnitOfWork unitOfWork, IPublisher publisher)
        {
            _participantRepository = participantRepository;
            _hobbyistRepository = hobbyistRepository;
            _artEventRepository= artEventRepository;
            _unitOfWork = unitOfWork;
            _publisher = publisher;
        }
        public async Task<string> Handle(RegisterParticipantToArtEventCommand request, CancellationToken cancellationToken)
        {
            ArtEvent artEvent = await _artEventRepository.FindByIdAsync(request.artEventId);
            Hobbyist hobbyist = await _hobbyistRepository.FindByIdAsync(request.hobbyistId);
            Domain.Model.Aggregates.Participant participant = new Domain.Model.Aggregates.Participant(
                id: 0,
                userName: "A",
                registerDateTime: new System.DateTime(),
                checkInDateTime: DateTime.UtcNow,
                hobbyistId: request.hobbyistId,
                artEventId: request.artEventId,
                hobbyist: hobbyist,
                artEvent: artEvent,
                collected: false);
            
            
            
            await _participantRepository.AddAsync(participant);
            await _unitOfWork.CompleteAsync();
            await _publisher.Publish(new ParticipantRegisteredEvent()
            {
                ArtistId = artEvent.ArtistId.Value,
                HobbyistId = hobbyist.HobbyistId
            });
            return "Your participation was registered: ";
        }
    }
}
