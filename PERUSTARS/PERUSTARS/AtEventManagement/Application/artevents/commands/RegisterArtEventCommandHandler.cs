﻿using MediatR;
using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.AtEventManagement.Domain.Model.Commads;
using PERUSTARS.AtEventManagement.Domain.Model.Repositories;
using PERUSTARS.AtEventManagement.Domain.Model.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace PERUSTARS.AtEventManagement.Application.artevents.commands
{
    public class RegisterArtEventCommandHandler : IRequestHandler<RegisterArtEventCommand, string>
    {
        IArtEventRepository _artEventRepository;
        public RegisterArtEventCommandHandler(IArtEventRepository artEventRepository)
        {
            _artEventRepository = artEventRepository;
        }
        public async Task<string> Handle(RegisterArtEventCommand request, CancellationToken cancellationToken)
        {
            var artEvent = new ArtEvent(
                id: 0,
                title: request.Title,
                description: request.Description,
                startDateTime: request.StartDateTime,
                location: request.Location,
                isOnline: request.IsOnline,
                artistId: request.ArtistId,
                currentStatus: ArtEventStatus.REGISTERED,
                participants:null,
                artist:null,
                collected:false
                );
            await _artEventRepository.AddAsync(artEvent);
            return "Registro exitoso";

        }
    }
}
