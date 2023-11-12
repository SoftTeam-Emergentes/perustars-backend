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
    public class CollectFollowedArtistDataCommandHandler : IRequestHandler<CollectFollowedArtistDataCommand, bool>
    {
        private readonly IMLTrainingDataRepository _trainingDataRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CollectFollowedArtistDataCommandHandler(IMLTrainingDataRepository trainingDataRepository,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _trainingDataRepository = trainingDataRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CollectFollowedArtistDataCommand command, CancellationToken cancellationToken)
        {
            MLTrainingData trainingData = _mapper.Map<MLTrainingData>(command);
            // Dado que se trata de el registro de un follower se asigna el score de 2
            trainingData.Score = 2;
            await _trainingDataRepository.AddAsync(trainingData);
            await _unitOfWork.CompleteAsync();
            return await Task.FromResult(true);
        }
    }
}
