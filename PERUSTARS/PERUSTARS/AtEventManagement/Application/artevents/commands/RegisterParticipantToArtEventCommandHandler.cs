using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.AtEventManagement.Domain.Model.Commads;
using PERUSTARS.AtEventManagement.Domain.Model.Repositories;
using PERUSTARS.ProfileManagement.Domain.Model.Aggregates;
using PERUSTARS.Shared.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Application.artevents.commands
{
    public class RegisterParticipantToArtEventCommandHandler// : IRequestHandler<RegisterParticipantToArtEventCommand, string>
    {
        //private readonly IParticipantRepository _participantRepository;
        //private readonly IHobbyistRepository _hobbyistRepository;
        //private readonly IArtEventRepository _artEventRepository;
        //private readonly IUnitOfWork _unitOfWork;
        //public RegisterParticipantToArtEventCommandHandler(IParticipantRepository participantRepository, IHobbyistRepository hobbyistRepository,IArtEventRepository artEventRepository, IUnitOfWork unitOfWork)
        //{
        //    _participantRepository = participantRepository;
        //    _hobbyistRepository = hobbyistRepository;
        //    _artEventRepository= artEventRepository;
        //    _unitOfWork = unitOfWork;
        //    
        //}
        public  string Handle(RegisterParticipantToArtEventCommand request, CancellationToken cancellationToken)
        {
            //ArtEvent artEvent = _artEventRepository.FindByIdAsync(request.artEventId);
            //Hobbyist hobbyist = _hobbyistRepository.findByIdAsync(request.hobbyistId);
            //Participant participant = new Participant(
            //    id: 0,
            //    userName: hobbyist.FirstName,
            //    registerDateTime: new System.DateTime(),
            //    checkInDateTime: null,
            //    hobbyistId: request.hobbyistId,
            //    artEventId: request.artEventId,
            //    hobbyist: hobbyist,
            //    artEvent: artEvent,
            //    collected: false);
            //
            //
            //
            //await _participantRepository.AddAsync(participant);
            //await _unitOfWork.CompleteAsync();
            return "Your participation was registered: ";
        }
    }
}
