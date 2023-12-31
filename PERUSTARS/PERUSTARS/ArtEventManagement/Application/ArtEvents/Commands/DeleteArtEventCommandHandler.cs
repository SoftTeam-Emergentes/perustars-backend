﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.ArtEventManagement.Domain.Model.Commads;
using PERUSTARS.ArtEventManagement.Domain.Model.Repositories;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtEventManagement.Application.ArtEvents.Commands
{
    public class DeleteArtEventCommandHandler : IRequestHandler<DeleteArtEventCommand, string>
    {
        private readonly IArtEventRepository _artEventRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteArtEventCommandHandler(IArtEventRepository artEventRepository, IUnitOfWork unitOfWork)
        {
            _artEventRepository = artEventRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(DeleteArtEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ArtEvent artEvent= _artEventRepository.FindByIdAsync(request.id).Result;
                if (artEvent != null) {
                    _artEventRepository.Remove(artEvent);
                    await _unitOfWork.CompleteAsync();
                    
                }
            }
            catch(Exception e) {
                throw new ApplicationException($"An error occurred while deleting the art event: {e.Message}");

            }
            return "Art event deleted";
        }
    }
}
