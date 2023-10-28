﻿using AutoMapper;
using MediatR;
using PERUSTARS.DataAnalytics.Domain.Model.Entities;
using PERUSTARS.DataAnalytics.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.DataAnalytics.Application.Commands.Handlers
{
    public class CollectEventLogDataCommandHandler : IRequestHandler<CollectEventLogDataCommand, bool>
    {
        private readonly IMLTrainingDataRepository _trainingDataRepository;
        private readonly IMapper _mapper;

        public CollectEventLogDataCommandHandler(IMLTrainingDataRepository trainingDataRepository)
        {
            _trainingDataRepository = trainingDataRepository;
        }

        public async Task<bool> Handle(CollectEventLogDataCommand request, CancellationToken cancellationToken)
        {
            MLTrainingData trainingData = _mapper.Map<MLTrainingData>(request);
            // Dado que se trata de el registro de un participante de un evento se asigna el score de 4
            trainingData.Score = 4;
            await _trainingDataRepository.AddAsync(trainingData);
            return await Task.FromResult(true);
        }
    }
}
