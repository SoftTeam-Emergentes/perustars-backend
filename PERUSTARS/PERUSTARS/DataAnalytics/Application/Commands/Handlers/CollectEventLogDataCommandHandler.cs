using AutoMapper;
using MediatR;
using PERUSTARS.DataAnalytics.Domain.Model.Commands;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.DataAnalytics.Domain.Repositories;
using System.Threading.Tasks;
using System.Threading;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.DataAnalytics.Application.Commands.Handlers
{
    public class CollectEventLogDataCommandHandler : IRequestHandler<CollectEventLogDataCommand, bool>
    {
        private readonly IMLTrainingDataRepository _trainingDataRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CollectEventLogDataCommandHandler(IMLTrainingDataRepository trainingDataRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _trainingDataRepository = trainingDataRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CollectEventLogDataCommand request, CancellationToken cancellationToken)
        {
            MLTrainingData trainingData = _mapper.Map<MLTrainingData>(request);
            // Dado que se trata de el registro de un participante de un evento se asigna el score de 4
            trainingData.Score = 4;
            await _trainingDataRepository.AddAsync(trainingData);
            await _unitOfWork.CompleteAsync();
            return await Task.FromResult(true);
        }
    }
}
