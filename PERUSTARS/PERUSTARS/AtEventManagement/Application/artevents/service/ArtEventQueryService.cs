using PERUSTARS.AtEventManagement.Domain.Model.Aggregates;
using PERUSTARS.AtEventManagement.Domain.Model.Repositories;
using PERUSTARS.AtEventManagement.Domain.Services.ArtEvent;
using System;
using System.Collections.Generic;

namespace PERUSTARS.AtEventManagement.Application.artevents.service
{
    public class ArtEventQueryService: IArtEventQueryService
    {
        private readonly IArtEventRepository _artEventRepository;
        public ArtEventQueryService(IArtEventRepository artEventRepository)
        {
            _artEventRepository = artEventRepository;
        }

        public void deleteArtEvent(long id)
        {
            ArtEvent artEvent = _artEventRepository.FindByIdAsync(id).Result;
            _artEventRepository.Remove(artEvent);
        }

        public IEnumerable<ArtEvent> getArtEventByArtistId(long id)
        {
            return _artEventRepository.findByArtistIdAsync(id).Result;
        }

        public ArtEvent getArtEventById(long id)
        {
            return _artEventRepository.FindByIdAsync(id).Result;
        }

        public IEnumerable<ArtEvent> getArtEvents()
        {
            return _artEventRepository.ListAsync().Result;
        }

        public IEnumerable<ArtEvent> getArtEventsByHobbyistId(long id)
        {
            return _artEventRepository.findByHobbyistIdAsync(id).Result;
        }
    }
}
