﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PERUSTARS.ArtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.ArtEventManagement.Domain.Model.Commads;
using PERUSTARS.ArtEventManagement.Domain.Model.Repositories;
using PERUSTARS.ArtEventManagement.Domain.Model.ValueObjects;
using PERUSTARS.Shared.Domain.Repositories;

namespace PERUSTARS.ArtEventManagement.Application.ArtEvents.Commands
{
    public class RegisterArtEventCommandHandler : IRequestHandler<RegisterArtEventCommand, string>
    {
        private readonly IArtEventRepository _artEventRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterArtEventCommandHandler(IArtEventRepository artEventRepository, IUnitOfWork unitOfWork)
        {
            _artEventRepository = artEventRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(RegisterArtEventCommand request, CancellationToken cancellationToken)
        {
            //Primero se debe validar si existe el artista con el Id dado

            //"return No existe el Artista con el Id dado"
            //-----------------------------------
            var artEvent = new ArtEvent(
                id: 0,
                title: request.Title,
                description: request.Description,
                startDateTime: request.StartDateTime,
                Location: request.Location,
                isOnline: request.IsOnline,
                artistId: request.ArtistId,
                currentStatus: ArtEventStatus.REGISTERED,
                Participants:null,
                Artist:null,
                collected:false
                );
            await _artEventRepository.AddAsync(artEvent);
            await _unitOfWork.CompleteAsync();
            return "Art event registered succesfully!!";

        }
    }
}