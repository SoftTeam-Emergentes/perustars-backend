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
    public class CollectArtworkReviewDataCommandHandler : IRequestHandler<CollectArtworkReviewDataCommand, bool>
    {
        private readonly IMLTrainingDataRepository _trainingDataRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CollectArtworkReviewDataCommandHandler(IMLTrainingDataRepository trainingDataRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _trainingDataRepository = trainingDataRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CollectArtworkReviewDataCommand command, CancellationToken cancellationToken)
        {
            // El commando ejecutado ya debería tener el score del 1 al 5
            MLTrainingData trainingData = _mapper.Map<MLTrainingData>(command);
            await _trainingDataRepository.AddAsync(trainingData);
            await _unitOfWork.CompleteAsync();
            return await Task.FromResult(true);
        }
    }
}
