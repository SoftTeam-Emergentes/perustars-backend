using AutoMapper;
using MediatR;
using PERUSTARS.DataAnalytics.Domain.Model.Commands;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.DataAnalytics.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Application.Commands.Handlers
{
    public class NotifyPenaltyApplyCommandHandler : IRequestHandler<NotifyPenaltyApplyCommand, bool>
    {
        private readonly IMLTrainingDataRepository _trainingDataRepository;
        private readonly IMapper _mapper;

        public NotifyPenaltyApplyCommandHandler(IMLTrainingDataRepository trainingDataRepository)
        {
            _trainingDataRepository = trainingDataRepository;
        }
        public async Task<bool> Handle(NotifyPenaltyApplyCommand command, CancellationToken cancellationToken)
        {
            MLTrainingData trainingData = _mapper.Map<MLTrainingData>(command);
            // Dado que se trata de la penalización a un hobbyist se asigna el score de -2
            trainingData.Score = -2;
            await _trainingDataRepository.AddAsync(trainingData);
            return await Task.FromResult(true);
        }
    }
}
