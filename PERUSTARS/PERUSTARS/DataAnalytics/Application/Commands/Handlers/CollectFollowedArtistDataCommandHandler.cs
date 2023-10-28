using AutoMapper;
using MediatR;
using PERUSTARS.DataAnalytics.Domain.Model.Commands;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.DataAnalytics.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Application.Commands.Handlers
{
    public class CollectFollowedArtistDataCommandHandler : IRequestHandler<CollectFollowedArtistDataCommand, bool>
    {
        private readonly IMLTrainingDataRepository _trainingDataRepository;
        private readonly IMapper _mapper;

        public CollectFollowedArtistDataCommandHandler(IMLTrainingDataRepository trainingDataRepository)
        {
            _trainingDataRepository = trainingDataRepository;
        }
        public async Task<bool> Handle(CollectFollowedArtistDataCommand command, CancellationToken cancellationToken)
        {
            MLTrainingData trainingData = _mapper.Map<MLTrainingData>(command);
            // Dado que se trata de el registro de un follower se asigna el score de 2
            trainingData.Score = 2;
            await _trainingDataRepository.AddAsync(trainingData);
            return await Task.FromResult(true);
        }
    }
}
