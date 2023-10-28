using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.AtEventManagement.Domain.Model.Commads;
using PERUSTARS.AtEventManagement.Domain.Model.Repositories;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Application.artevents.commands
{
    public class RegisterParticipantToArtEventCommandHandler : IRequestHandler<RegisterParticipantToArtEventCommand, string>
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly IHobbyistRepository _hobbyistRepository;
        private readonly IArtEventRepository _artEventRepository;
        public RegisterParticipantToArtEventCommandHandler(IParticipantRepository participantRepository, IHobbyistRepository hobbyistRepository,IArtEventRepository artEventRepository)
        {
            _participantRepository = participantRepository;
            _hobbyistRepository = hobbyistRepository;
            _artEventRepository= artEventRepository;
            
        }
        public Task<string> Handle(RegisterParticipantToArtEventCommand request, CancellationToken cancellationToken)
        {
            ArtEvent artEvent = _artEventRepository.FindByIdAsync(request.artEventId);
            Hobbyist hobbyist = _hobbyistRepository.findByIdAsync(request.hobbyistId);
            Participant participant = new Participant(
                id: 0,
                userName: hobbyist.FirstName,
                registerDateTime: new System.DateTime(),
                checkInDateTime: null,
                hobbyistId: request.hobbyistId,
                artEventId: request.artEventId,
                hobbyist: hobbyist,
                artEvent: artEvent,
                collected: false);



            _participantRepository.AddAsync(participant);
            return Task.FromResult("Your participation was registered: "+participant.UserName);
        }
    }
}
