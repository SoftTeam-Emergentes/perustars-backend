using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtEventManagement.Domain.Model.Commads;
using PERUSTARS.ArtEventManagement.Domain.Model.Repositories;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtEventManagement.Application.Participant.Command
{
    public class DeleteParticipantCommandHandler:IRequestHandler<DeleteParticipantCommand,string>
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteParticipantCommandHandler(IParticipantRepository participantRepository, IUnitOfWork unitOfWork)
        {
            _participantRepository = participantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(DeleteParticipantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Domain.Model.Aggregates.Participant p = _participantRepository.FindByIdAsync(request.id).Result;
                if (p != null)
                {
                    _participantRepository.Remove(p);
                    await _unitOfWork.CompleteAsync();
                    return "Participant deleted";
                }
                else {
                    return "Participant with the given Id doesn't exist";
                }
            }
            catch (Exception e) {
                throw new ApplicationException($"An error occurred while deleting the participant: {e.Message}");
            }
            
        }
    }
}
